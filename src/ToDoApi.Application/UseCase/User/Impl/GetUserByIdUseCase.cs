using ToDoApi.ToDoApi.Application.Exception.User;
using ToDoApi.ToDoApi.Domain.Repository;

namespace ToDoApi.ToDoApi.Application.UseCase.User.Impl;

public class GetUserByIdUseCase(IUserRepository userRepository) : IGetUserByIdUseCase
{
    public async Task<Domain.Model.User> ExecuteAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user == null)
        {
            throw new UserNotFoundException($"User with id: {id} not found.");
        }

        return user;
    }
}