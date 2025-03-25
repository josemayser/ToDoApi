using System.Net;
using ToDoApi.ToDoApi.Application.Attribute;

namespace ToDoApi.ToDoApi.Application.Exception;

[ExceptionHttpStatusCode(HttpStatusCode.NotFound)]
public class EntityNotFoundException(string message) : System.Exception(message);