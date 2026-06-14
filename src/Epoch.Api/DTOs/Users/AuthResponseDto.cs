namespace Epoch.Api.DTOs.Users;

public record AuthResponseDto(
    string Token,
    string Username,
    string Email
);