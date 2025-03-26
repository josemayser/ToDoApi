using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Shared;

public interface ISessionContext
{
    User? AuthenticationUser { get; }
}