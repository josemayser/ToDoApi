namespace ToDoApi.ToDoApi.Application.UseCase.User;

public interface IGetAuthenticatedUser
{
    Domain.Model.User Execute();
}