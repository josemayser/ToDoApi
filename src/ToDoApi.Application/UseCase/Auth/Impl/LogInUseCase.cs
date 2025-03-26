using ToDoApi.ToDoApi.Application.Exception.Auth;
using ToDoApi.ToDoApi.Application.Exception.User;
using ToDoApi.ToDoApi.Application.Shared;
using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.UseCase.Auth.Impl;

public class LogInUseCase(
    IGetUserByEmailUseCase getUserByEmailUseCase,
    IPasswordHasher passwordHasher,
    ITokenManager tokenManager) : ILogInUseCase
{
    public async Task<AuthResult> ExecuteAsync(string email, string password)
    {
        try
        {
            var user = await getUserByEmailUseCase.ExecuteAsync(email.ToLower());
            if (!passwordHasher.Verify(password, user.Password))
            {
                throw new InvalidCredentialsException();
            }

            var (token, expiresAt) = tokenManager.GenerateToken(user);
            return new AuthResult { Token = token, ExpiresAt = expiresAt };
        }
        catch (UserNotFoundException exception)
        {
            throw new InvalidCredentialsException(exception);
        }
    }
}