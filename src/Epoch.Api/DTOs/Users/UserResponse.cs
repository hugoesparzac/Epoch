namespace Epoch.Api.DTOs.Users;

public record UserResponse(
    Guid Id,
    string Username,
    string Email,
    string PreferredTimeZone
);