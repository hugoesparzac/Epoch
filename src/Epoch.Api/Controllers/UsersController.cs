using Epoch.Api.DTOs.Users;
using Epoch.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epoch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserResponseDto>> GetById(Guid id)
    {
        var user = await userService.GetByIdAsync(id);

        if (user is null)
            return NotFound();

        return Ok(user);
    }
}