using Epoch.Api.DTOs.Users;

namespace Epoch.Api.Services;

public interface IUserService
{
    Task<UserResponse> RegisterAsync(CreateUserRequest request);
}