using ToDoApi.ToDoApi.Application.Shared;

namespace ToDoApi.ToDoApi.Infrastructure.Shared;

public class BcryptPasswordHasher : IPasswordHasher
{
    public string Hash(string plainPassword)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainPassword);
    }

    public bool Verify(string plainPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }
}