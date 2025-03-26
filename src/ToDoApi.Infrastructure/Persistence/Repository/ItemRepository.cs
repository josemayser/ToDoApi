using Microsoft.EntityFrameworkCore;
using ToDoApi.ToDoApi.Domain.Model;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Infrastructure.Persistence.Repository;

public class ItemRepository(AppDbContext dbContext) : IItemRepository
{
    public async Task<Item?> GetByIdAsync(Guid id)
    {
        return await dbContext.Items.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<Item>> GetByUserIdAsync(Guid userId)
    {
        return await dbContext.Items.Where(i => i.UserId == userId).OrderByDescending(i => i.CreatedAt).ToListAsync();
    }

    public async Task<Item> AddAsync(Item item)
    {
        dbContext.Items.Add(item);
        await dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<Item> UpdateAsync(Item item)
    {
        dbContext.Items.Update(item);
        await dbContext.SaveChangesAsync();
        return item;
    }

    public async Task RemoveAsync(Item item)
    {
        dbContext.Items.Remove(item);
        await dbContext.SaveChangesAsync();
    }
}