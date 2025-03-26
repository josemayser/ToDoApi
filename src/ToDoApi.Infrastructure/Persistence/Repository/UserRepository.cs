using Microsoft.EntityFrameworkCore;
using ToDoApi.ToDoApi.Domain.Model;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Infrastructure.Persistence.Repository;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> AddAsync(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user;
    }
}