using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Service.Impl;

public class UserService(IGetAuthenticatedUser getAuthenticatedUser) : IUserService
{
    public User GetAuthenticatedUser()
    {
        return getAuthenticatedUser.Execute();
    }
}