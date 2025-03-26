using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Service;

public interface IItemService
{
    Task<List<Item>> GetItemsByAuthenticatedUserAsync();

    Task<Item> GetItemByItemIdAsync(Guid itemId);

    Task<Item> CreateItemAsync(Item item);

    Task<Item> UpdateItemAsync(Guid itemId, Item item);

    Task DeleteItemAsync(Guid itemId);
}