using Libro.Api.Models;

namespace Libro.Api.Infrastructure.Identity;

public interface ITokenService
{
    string BuildToken(string key, string issuer, string audience, UserEntity user);
    bool IsTokenValid(string key, string issuer, string audience, string token);
}