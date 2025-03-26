namespace ToDoApi.ToDoApi.Application.UseCase.Item;

public interface IGetItemByIdUseCase
{
    Task<Domain.Model.Item> ExecuteAsync(Guid id);
}