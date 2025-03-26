using System.Net;
using ToDoApi.ToDoApi.Application.Attribute;

namespace ToDoApi.ToDoApi.Application.Exception.Auth;

[ExceptionHttpStatusCode(HttpStatusCode.Unauthorized)]
public class InvalidCredentialsException : System.Exception
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {
    }

    public InvalidCredentialsException(System.Exception innerException) : base("Invalid credentials.", innerException)
    {
    }
}