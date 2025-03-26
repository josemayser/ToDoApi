namespace ToDoApi.ToDoApi.Application.UseCase.Item;

public interface IDeleteItemUseCase
{
    Task ExecuteAsync(Guid id);
}