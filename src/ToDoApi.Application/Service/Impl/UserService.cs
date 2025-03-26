using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Service.Impl;

public class UserService(IGetAuthenticatedUserUseCase getAuthenticatedUserUseCase) : IUserService
{
    public User GetAuthenticatedUser()
    {
        return getAuthenticatedUserUseCase.Execute();
    }
}