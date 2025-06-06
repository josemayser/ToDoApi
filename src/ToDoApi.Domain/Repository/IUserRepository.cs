using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Domain.Repository;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);

    Task<User?> GetByEmailAsync(string email);

    Task<User> AddAsync(User user);
}