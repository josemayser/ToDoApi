using ToDoApi.ToDoApi.Application.UseCase.Auth;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Service.Impl;

public class AuthService(IRegisterUserUseCase registerUserUseCase) : IAuthService
{
    public async Task<User> RegisterUserAsync(User user)
    {
        return await registerUserUseCase.ExecuteAsync(user);
    }
}