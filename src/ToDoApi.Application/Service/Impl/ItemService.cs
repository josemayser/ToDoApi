using ToDoApi.ToDoApi.Application.UseCase.Item;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Service.Impl;

public class ItemService(
    IGetItemsByAuthenticatedUserUseCase getItemsByAuthenticatedUserUseCase,
    IGetItemByIdUseCase getItemByIdUseCase,
    ICreateItemUseCase createItemUseCase,
    IUpdateItemUseCase updateItemUseCase,
    IDeleteItemUseCase deleteItemUseCase) : IItemService
{
    public async Task<List<Item>> GetItemsByAuthenticatedUserAsync()
    {
        return await getItemsByAuthenticatedUserUseCase.ExecuteAsync();
    }

    public async Task<Item> GetItemByItemIdAsync(Guid itemId)
    {
        return await getItemByIdUseCase.ExecuteAsync(itemId);
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        return await createItemUseCase.ExecuteAsync(item);
    }

    public async Task<Item> UpdateItemAsync(Guid itemId, Item item)
    {
        return await updateItemUseCase.ExecuteAsync(itemId, item);
    }

    public async Task DeleteItemAsync(Guid itemId)
    {
        await deleteItemUseCase.ExecuteAsync(itemId);
    }
}