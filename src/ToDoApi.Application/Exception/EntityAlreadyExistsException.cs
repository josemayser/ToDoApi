using System.Net;
using ToDoApi.ToDoApi.Application.Attribute;

namespace ToDoApi.ToDoApi.Application.Exception;

[ExceptionHttpStatusCode(HttpStatusCode.Conflict)]
public class EntityAlreadyExistsException(string message) : System.Exception(message);