namespace ToDoApi.ToDoApi.Infrastructure.Exception;

public class TokenValidationException : System.Exception
{
    public TokenValidationException(string message) : base(message)
    {
    }

    public TokenValidationException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}