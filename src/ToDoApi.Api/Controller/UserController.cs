using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.ToDoApi.Api.Dto.Response;
using ToDoApi.ToDoApi.Application.Service;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Api.Controller;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService, IMapper mapper) : ControllerBase
{
    [HttpGet("authenticated")]
    public IActionResult GetAuthenticatedUser()
    {
        var authenticatedUser = userService.GetAuthenticatedUser();
        var response = mapper.Map<User, UserResponse>(authenticatedUser);
        return Ok(response);
    }
}