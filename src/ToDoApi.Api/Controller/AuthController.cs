using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.ToDoApi.Api.Dto.Request;
using ToDoApi.ToDoApi.Api.Dto.Response;
using ToDoApi.ToDoApi.Application.Service;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Api.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController(IMapper mapper, IAuthService authService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("user-registration")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        var user = mapper.Map<RegisterUserRequest, User>(request);
        var registeredUser = await authService.RegisterUserAsync(user);
        var response = mapper.Map<User, UserResponse>(registeredUser);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LogIn([FromBody] LogInRequest request)
    {
        var result = await authService.LogInAsync(request.Email, request.Password);
        return Ok(result);
    }
}