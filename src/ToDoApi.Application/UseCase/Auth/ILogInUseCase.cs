using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.UseCase.Auth;

public interface ILogInUseCase
{
    Task<AuthResult> ExecuteAsync(string email, string password);
}