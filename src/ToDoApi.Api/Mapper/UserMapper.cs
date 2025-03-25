using AutoMapper;
using ToDoApi.ToDoApi.Api.Dto.Request;
using ToDoApi.ToDoApi.Api.Dto.Response;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Api.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<RegisterUserRequest, User>();

        CreateMap<User, UserResponse>();
    }
}