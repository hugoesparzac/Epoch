using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Epoch.Api.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Epoch.Api.Middlewares.Security;

public sealed class JwtProvider(IConfiguration configuration) : IJwtProvider
{
    public string GenerateToken(User user)
    {
        string secretKey = configuration["Jwt:Key"]!;
        string issuer = configuration["Jwt:Issuer"]!;
        string audience = configuration["Jwt:Audience"]!;
        int expirationMinutes = int.Parse(configuration["Jwt:ExpirationInMinutes"]!);
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = credentials
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }
}