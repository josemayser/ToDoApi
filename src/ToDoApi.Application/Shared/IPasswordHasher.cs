namespace ToDoApi.ToDoApi.Application.Shared;

public interface IPasswordHasher
{
    string Hash(string plainPassword);
    bool Verify(string plainPassword, string hashedPassword);
}