namespace ToDoApi.ToDoApi.Application.UseCase.Item;

public interface IGetItemsByAuthenticatedUserUseCase
{
    Task<List<Domain.Model.Item>> ExecuteAsync();
}