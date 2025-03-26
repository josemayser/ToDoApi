namespace ToDoApi.ToDoApi.Application.UseCase.User;

public interface IGetAuthenticatedUserUseCase
{
    Domain.Model.User Execute();
}