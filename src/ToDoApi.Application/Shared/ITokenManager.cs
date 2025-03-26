using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Application.Shared;

public interface ITokenManager
{
    (string Token, DateTimeOffset ExpiresAt) GenerateToken(User user);

    Guid ValidateTokenAndGetUserId(string token);
}