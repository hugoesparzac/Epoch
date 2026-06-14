using Epoch.Api.DTOs.Users;

namespace Epoch.Api.Services;

public interface IUserService
{
    Task<UserResponseDto> RegisterAsync(CreateUserRequestDto requestDto);
    Task<UserResponseDto?> GetByIdAsync(Guid id);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto requestDto);
}