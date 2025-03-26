using System.Net;
using ToDoApi.ToDoApi.Application.Attribute;

namespace ToDoApi.ToDoApi.Application.Exception;

[ExceptionHttpStatusCode(HttpStatusCode.Forbidden)]
public class EntityNotAssociatedException(string message) : System.Exception(message);