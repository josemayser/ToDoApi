using ToDoApi.ToDoApi.Application.Exception.User;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.User.Impl;

public class GetUserByEmailUseCase(IUserRepository userRepository) : IGetUserByEmailUseCase
{
    public async Task<Domain.Model.User> ExecuteAsync(string email)
    {
        var user = await userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            throw new UserNotFoundException($"User with email: '{email}' not found.");
        }

        return user;
    }
}