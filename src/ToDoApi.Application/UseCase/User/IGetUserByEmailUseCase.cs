namespace ToDoApi.ToDoApi.Application.UseCase.User;

public interface IGetUserByEmailUseCase
{
    Task<Domain.Model.User> ExecuteAsync(string email);
}