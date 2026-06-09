using Epoch.Api.DTOs.Users;
using Epoch.Api.Entities;
using Epoch.Api.Mappers;
using Epoch.Api.Repositories;

namespace Epoch.Api.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<UserResponse> RegisterAsync(CreateUserRequest request)
    {
        if (await userRepository.ExistsByEmailAsync(request.Email))
        {
            throw new InvalidOperationException("El correo ya está registrado.");
        }

        if (await userRepository.ExistsByUsernameAsync(request.Username))
        {
            throw new InvalidOperationException("El nombre de usuario ya está en uso.");
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        User newUser = request.ToEntity(passwordHash);
        
        await userRepository.AddAsync(newUser);
        await userRepository.SaveChangesAsync();
        
        return newUser.ToResponse();
    }
}