using Epoch.Api.DTOs.Users;
using Epoch.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Epoch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserResponseDto>> Register(CreateUserRequestDto requestDto)
    {
        var response = await userService.RegisterAsync(requestDto);
        return CreatedAtAction(
            "GetById",
            "Users",
            new { id = response.Id },
            response);
    }
    
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginRequestDto requestDto)
    {
        var response = await userService.LoginAsync(requestDto);
        return Ok(response);
    }
}