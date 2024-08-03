namespace Libro.Api.Infrastructure;

public class UnitOfWorkAdapter(AppDbContext dbContext) : IUnitOfWork
{
    public async Task CommitAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}