using ToDoApi.ToDoApi.Application.UseCase.Auth;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Service.Impl;

public class AuthService(IRegisterUserUseCase registerUserUseCase, ILogInUseCase logInUseCase) : IAuthService
{
    public async Task<User> RegisterUserAsync(User user)
    {
        return await registerUserUseCase.ExecuteAsync(user);
    }

    public async Task<AuthResult> LogInAsync(string email, string password)
    {
        return await logInUseCase.ExecuteAsync(email, password);
    }
}