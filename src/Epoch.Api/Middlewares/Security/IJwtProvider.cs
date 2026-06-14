using Epoch.Api.Entities;

namespace Epoch.Api.Middlewares.Security;

public interface IJwtProvider
{
    string GenerateToken(User user);
}