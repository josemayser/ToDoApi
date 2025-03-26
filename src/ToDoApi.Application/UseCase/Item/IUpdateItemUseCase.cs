namespace ToDoApi.ToDoApi.Application.UseCase.Item;

public interface IUpdateItemUseCase
{
    Task<Domain.Model.Item> ExecuteAsync(Guid id, Domain.Model.Item item);
}