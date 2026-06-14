using Epoch.Api.DTOs.Users;
using Epoch.Api.Entities;
using Epoch.Api.Mappers;
using Epoch.Api.Middlewares.Security;
using Epoch.Api.Repositories;

namespace Epoch.Api.Services;

public class UserService(IUserRepository userRepository, IJwtProvider jwtProvider) : IUserService
{
    public async Task<UserResponseDto> RegisterAsync(CreateUserRequestDto requestDto)
    {
        if (await userRepository.ExistsByEmailAsync(requestDto.Email))
        {
            throw new InvalidOperationException("El correo ya está registrado.");
        }

        if (await userRepository.ExistsByUsernameAsync(requestDto.Username))
        {
            throw new InvalidOperationException("El nombre de usuario ya está en uso.");
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(requestDto.Password);
        
        User newUser = requestDto.ToEntity(passwordHash);
        
        await userRepository.AddAsync(newUser);
        await userRepository.SaveChangesAsync();
        
        return newUser.ToResponse();
    }
    
    public async Task<UserResponseDto?> GetByIdAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);
        
        return user?.ToResponse();
    }
    
    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        var user = await userRepository.GetByEmailAsync(requestDto.Email);
        
        if (user is null || !BCrypt.Net.BCrypt.Verify(requestDto.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Credenciales inválidas.");
        }
        
        string token = jwtProvider.GenerateToken(user);
        
        return new AuthResponseDto(
            Token: token, 
            Username: user.Username, 
            Email: user.Email
        );
    }
}