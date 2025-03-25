using System.Security.Cryptography;
using System.Text;
using ToDoApi.ToDoApi.Application.Exception.User;
using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.Auth.Impl;

public class RegisterUserUseCase(IGetUserByEmailUseCase getUserByEmailUseCase, IUserRepository userRepository)
    : IRegisterUserUseCase
{
    public async Task<Domain.Model.User> ExecuteAsync(Domain.Model.User user)
    {
        var userEmail = user.Email.Trim();
        try
        {
            await getUserByEmailUseCase.ExecuteAsync(userEmail.ToLower());
            throw new UserAlreadyExistsException($"Already exists a User with the email: '{userEmail}'.");
        }
        catch (UserNotFoundException _)
        {
        }

        user.Email = userEmail.ToLower();
        user.Password = HashPassword(user.Password);
        return await userRepository.AddAsync(user);
    }

    private string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}