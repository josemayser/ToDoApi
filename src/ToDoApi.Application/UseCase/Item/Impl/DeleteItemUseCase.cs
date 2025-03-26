using ToDoApi.ToDoApi.Application.Exception.Item;
using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.Item.Impl;

public class DeleteItemUseCase(
    IGetItemByIdUseCase getItemByIdUseCase,
    IGetAuthenticatedUserUseCase getAuthenticatedUserUseCase,
    IItemRepository itemRepository) : IDeleteItemUseCase
{
    public async Task ExecuteAsync(Guid id)
    {
        var itemToDelete = await getItemByIdUseCase.ExecuteAsync(id);
        var authenticatedUser = getAuthenticatedUserUseCase.Execute();
        if (itemToDelete.UserId != authenticatedUser.Id)
        {
            throw new ItemNotAssociatedException("Item not associated with authenticated user");
        }

        await itemRepository.RemoveAsync(itemToDelete);
    }
}