using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.Item.Impl;

public class GetItemsByAuthenticatedUserUseCase(
    IGetAuthenticatedUserUseCase getAuthenticatedUserUseCase,
    IItemRepository itemRepository) : IGetItemsByAuthenticatedUserUseCase
{
    public async Task<List<Domain.Model.Item>> ExecuteAsync()
    {
        var authenticatedUser = getAuthenticatedUserUseCase.Execute();
        return await itemRepository.GetByUserIdAsync(authenticatedUser.Id);
    }
}