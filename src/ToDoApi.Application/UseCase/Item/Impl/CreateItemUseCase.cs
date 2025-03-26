using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.Item.Impl;

public class CreateItemUseCase(IGetAuthenticatedUserUseCase getAuthenticatedUserUseCase, IItemRepository itemRepository)
    : ICreateItemUseCase
{
    public async Task<Domain.Model.Item> ExecuteAsync(Domain.Model.Item item)
    {
        var authenticatedUser = getAuthenticatedUserUseCase.Execute();
        item.UserId = authenticatedUser.Id;
        return await itemRepository.AddAsync(item);
    }
}