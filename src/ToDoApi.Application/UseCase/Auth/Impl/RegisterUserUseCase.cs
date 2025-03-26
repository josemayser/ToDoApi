using ToDoApi.ToDoApi.Application.Exception.User;
using ToDoApi.ToDoApi.Application.Shared;
using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.Auth.Impl;

public class RegisterUserUseCase(
    IGetUserByEmailUseCase getUserByEmailUseCase,
    IPasswordHasher passwordHasher,
    IUserRepository userRepository)
    : IRegisterUserUseCase
{
    public async Task<Domain.Model.User> ExecuteAsync(Domain.Model.User user)
    {
        var userEmail = user.Email.Trim();
        try
        {
            await getUserByEmailUseCase.ExecuteAsync(userEmail.ToLower());
            throw new UserAlreadyExistsException($"Already exists a User with the email: {userEmail}.");
        }
        catch (UserNotFoundException ignored)
        {
        }

        user.Email = userEmail.ToLower();
        user.Password = passwordHasher.Hash(user.Password);
        return await userRepository.AddAsync(user);
    }
}