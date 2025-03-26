using ToDoApi.ToDoApi.Application.Exception.User;
using ToDoApi.ToDoApi.Application.Shared;

namespace ToDoApi.ToDoApi.Application.UseCase.User.Impl;

public class GetAuthenticatedUser(ISessionContext sessionContext) : IGetAuthenticatedUser
{
    public Domain.Model.User Execute()
    {
        var authenticatedUser = sessionContext.AuthenticationUser;
        if (authenticatedUser == null)
        {
            throw new UserNotFoundException("Authenticated user not found.");
        }

        return authenticatedUser;
    }
}