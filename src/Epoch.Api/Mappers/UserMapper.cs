using Epoch.Api.DTOs.Users;
using Epoch.Api.Entities;

namespace Epoch.Api.Mappers;

public static class UserMapper
{
    public static UserResponseDto ToResponse(this User u)
    {
        return new UserResponseDto(
            Id: u.Id,
            Username: u.Username,
            Email: u.Email,
            PreferredTimeZone: u.PreferredTimeZone
        );
    }
    
    public static User ToEntity(this CreateUserRequestDto requestDto, string hashedPassword)
    {
        return new User
        {
            Username = requestDto.Username,
            NormalizedUsername = requestDto.Username.ToUpperInvariant(),
            Email = requestDto.Email,
            NormalizedEmail = requestDto.Email.ToUpperInvariant(),
            PasswordHash = hashedPassword,
            PreferredTimeZone = requestDto.PreferredTimeZone
        };
    }
}