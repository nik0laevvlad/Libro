using Libro.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Libro.Api.Infrastructure.Identity;

public class UserRepositoryAdapter(AppDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(UserEntity user)
    {
        await dbContext.Users.AddAsync(user);
    }

    public async Task<UserEntity> ByIdAsync(Guid id)
    {
        return await dbContext.Users.FindAsync(id) ?? throw new Exception("User not found");
    }

    public async Task<UserEntity?> GetValidUserOrDefault(string username)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Username == username);
        return user;
    }

    public async Task<bool> IsUserExists(string username)
    {
        return await dbContext.Users.AnyAsync(user => user.Username == username);
    }
}