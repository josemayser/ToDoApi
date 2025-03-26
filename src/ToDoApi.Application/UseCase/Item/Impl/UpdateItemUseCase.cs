using ToDoApi.ToDoApi.Application.Exception.Item;
using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.Item.Impl;

public class UpdateItemUseCase(
    IGetItemByIdUseCase getItemByIdUseCase,
    IGetAuthenticatedUserUseCase getAuthenticatedUserUseCase,
    IItemRepository itemRepository) : IUpdateItemUseCase
{
    public async Task<Domain.Model.Item> ExecuteAsync(Guid id, Domain.Model.Item item)
    {
        var itemToUpdate = await getItemByIdUseCase.ExecuteAsync(id);
        var authenticatedUser = getAuthenticatedUserUseCase.Execute();
        if (itemToUpdate.UserId != authenticatedUser.Id)
        {
            throw new ItemNotAssociatedException("Item not associated with authenticated user");
        }

        itemToUpdate.UpdatedAt = DateTimeOffset.UtcNow;
        itemToUpdate.Title = item.Title;
        itemToUpdate.Description = item.Description;
        itemToUpdate.IsCompleted = item.IsCompleted;
        itemToUpdate.DueDate = item.DueDate;
        return await itemRepository.UpdateAsync(itemToUpdate);
    }
}