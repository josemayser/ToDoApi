using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoApi.ToDoApi.Application.Shared;
using ToDoApi.ToDoApi.Domain.Model;
using ToDoApi.ToDoApi.Infrastructure.Exception;

namespace ToDoApi.ToDoApi.Infrastructure.Shared;

public class TokenManager(IConfiguration configuration) : ITokenManager
{
    public (string Token, DateTimeOffset ExpiresAt) GenerateToken(User user)
    {
        var expiresAt = DateTimeOffset.Now.AddHours(1);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Exp, expiresAt.ToUnixTimeSeconds().ToString())
        };
        // TODO Validate if Jwt:Key property exists
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: expiresAt.UtcDateTime,
            signingCredentials: signingCredentials);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return (token, expiresAt);
    }

    public Guid ValidateTokenAndGetUserId(string token)
    {
        try
        {
            // TODO Validate if Jwt:Key property exists
            var principal = new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                ValidateIssuer = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["Jwt:Audience"],
                ClockSkew = TimeSpan.Zero
            }, out _);
            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
                throw new TokenValidationException("Invalid token.");
            }

            return userId;
        }
        catch (SecurityTokenExpiredException e)
        {
            throw new TokenValidationException("Token expired.", e);
        }
        catch (SecurityTokenInvalidSignatureException e)
        {
            throw new TokenValidationException("Invalid token signature.", e);
        }
        catch (System.Exception e)
        {
            throw new TokenValidationException("Invalid token.", e);
        }
    }
}