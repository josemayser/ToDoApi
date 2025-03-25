namespace ToDoApi.ToDoApi.Application.UseCase.Auth;

public interface IRegisterUserUseCase
{
    Task<Domain.Model.User> ExecuteAsync(Domain.Model.User user);
}