namespace ToDoApi.ToDoApi.Application.UseCase.Item;

public interface ICreateItemUseCase
{
    Task<Domain.Model.Item> ExecuteAsync(Domain.Model.Item item);
}