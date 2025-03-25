using System.Net;

namespace ToDoApi.ToDoApi.Application.Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class ExceptionHttpStatusCode(HttpStatusCode httpStatusCode) : System.Attribute
{
    public HttpStatusCode HttpStatusCode { get; } = httpStatusCode;
}