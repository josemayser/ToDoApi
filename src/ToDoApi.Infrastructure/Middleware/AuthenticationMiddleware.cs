using Microsoft.AspNetCore.Authorization;
using ToDoApi.ToDoApi.Application.Exception.User;
using ToDoApi.ToDoApi.Application.Shared;
using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Infrastructure.Exception;

namespace ToDoApi.ToDoApi.Infrastructure.Middleware;

public class AuthenticationMiddleware(ITokenManager tokenManager, IGetUserByIdUseCase getUserByIdUseCase) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var endpoint = context.GetEndpoint();
        if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() is not null)
        {
            await next(context);
            return;
        }

        var token = context.Request.Headers.Authorization.FirstOrDefault();
        if (string.IsNullOrWhiteSpace(token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Token is required.");
            return;
        }

        if (!token.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid token.");
            return;
        }

        try
        {
            var userId = tokenManager.ValidateTokenAndGetUserId(token["Bearer ".Length..]);
            try
            {
                var user = await getUserByIdUseCase.ExecuteAsync(userId);
                context.Items["User"] = user;
                await next(context);
            }
            catch (UserNotFoundException ignored)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid token.");
            }
        }
        catch (TokenValidationException e)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(e.Message);
        }
    }
}