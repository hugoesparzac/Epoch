using Epoch.Api.DTOs.Users;
using Epoch.Api.Entities;

namespace Epoch.Api.Mappers;

public static class UserMapper
{
    public static UserResponse ToResponse(this User u)
    {
        return new UserResponse(
            Id: u.Id,
            Username: u.Username,
            Email: u.Email,
            PreferredTimeZone: u.PreferredTimeZone
        );
    }
    
    public static User ToEntity(this CreateUserRequest request, string hashedPassword)
    {
        return new User
        {
            Username = request.Username,
            NormalizedUsername = request.Username.ToUpperInvariant(),
            Email = request.Email,
            NormalizedEmail = request.Email.ToUpperInvariant(),
            PasswordHash = hashedPassword,
            PreferredTimeZone = request.PreferredTimeZone
        };
    }
}