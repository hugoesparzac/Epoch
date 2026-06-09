using Epoch.Api.Entities;

namespace Epoch.Api.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByUsernameAsync(string username);
    
    Task AddAsync(User user);
    Task SaveChangesAsync();
}