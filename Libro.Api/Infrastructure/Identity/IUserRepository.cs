using Libro.Api.Models;

namespace Libro.Api.Infrastructure.Identity;

public interface IUserRepository
{
    Task AddAsync(UserEntity user);
    Task<UserEntity> ByIdAsync(Guid id);
    Task<UserEntity?> GetValidUserOrDefault(string username);
    Task<bool> IsUserExists(string username);
}