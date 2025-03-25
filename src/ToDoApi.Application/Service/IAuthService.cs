using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Service;

public interface IAuthService
{
    Task<User> RegisterUserAsync(User user);
}