namespace Epoch.Api.DTOs.Users;

public record UserResponseDto(
    Guid Id,
    string Username,
    string Email,
    string PreferredTimeZone
);