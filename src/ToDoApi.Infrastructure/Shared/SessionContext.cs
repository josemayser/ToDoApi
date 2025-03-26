using ToDoApi.ToDoApi.Application.Shared;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Infrastructure.Shared;

public class SessionContext(IHttpContextAccessor httpContextAccessor) : ISessionContext
{
    public User? AuthenticationUser => httpContextAccessor.HttpContext?.Items["User"] as User;
}