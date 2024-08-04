using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Libro.Api.Models;
using Microsoft.IdentityModel.Tokens;

namespace Libro.Api.Infrastructure.Identity;

public class TokenService : ITokenService
{
    private const double ExpiryDurationHours = 3;

    public string BuildToken(string key, string issuer, string audience, UserEntity user)
    {
        var claims = new List<Claim> {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Name, user.Username),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
            expires: DateTime.Now.AddHours(ExpiryDurationHours), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public bool IsTokenValid(string key, string issuer, string audience, string token)
    {
        var mySecret = Encoding.UTF8.GetBytes(key);
        var mySecurityKey = new SymmetricSecurityKey(mySecret);
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = mySecurityKey,
                }, out _);
        }
        catch
        {
            return false;
        }
        return true;
    }
}