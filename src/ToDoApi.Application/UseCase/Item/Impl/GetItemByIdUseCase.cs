using ToDoApi.ToDoApi.Application.Exception.Item;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.Item.Impl;

public class GetItemByIdUseCase(IItemRepository itemRepository) : IGetItemByIdUseCase
{
    public async Task<Domain.Model.Item> ExecuteAsync(Guid id)
    {
        var item = await itemRepository.GetByIdAsync(id);
        if (item == null)
        {
            throw new ItemNotFoundException($"Item with id: {id} not found.");
        }

        return item;
    }
}