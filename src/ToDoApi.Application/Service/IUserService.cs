using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Service;

public interface IUserService
{
    User GetAuthenticatedUser();
}