namespace ToDoApi.ToDoApi.Application.UseCase.User;

public interface IGetUserByIdUseCase
{
    Task<Domain.Model.User> ExecuteAsync(Guid id);
}