using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Domain.Repository;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid id);
    Task<List<Item>> GetByUserIdAsync(Guid userId);
    Task<Item> AddAsync(Item item);
    Task<Item> UpdateAsync(Item item);
    Task RemoveAsync(Item item);
}