namespace ToDoApi.ToDoApi.Domain.Model;

public class AuthResult
{
    public string Token { get; set; } = null!;
    public DateTimeOffset ExpiresAt { get; set; }
}