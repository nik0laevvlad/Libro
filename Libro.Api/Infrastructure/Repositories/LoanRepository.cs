using Libro.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Libro.Api.Infrastructure.Repositories;

public class LoanRepository(AppDbContext dbContext) : ILoanRepository
{
    public async Task AddAsync(Loan loan)
    {
        await dbContext.Loans.AddAsync(loan);
    }

    public async Task<Loan[]> GetAllAsync(Guid? userId = null)
    {
        var queryable = dbContext.Loans.AsQueryable();

        if (userId.HasValue)
        {
            queryable = queryable.Where(x => x.UserId == userId);
        }

        return await queryable.ToArrayAsync();
    }

    public async Task<Loan> GetAsync(Guid id)
    {
        return await dbContext.Loans.FindAsync(id) ?? throw new Exception("Loan not found");
    }

    public async Task DeleteAsync(Guid id)
    {
        var loan = await GetAsync(id);
        dbContext.Loans.Remove(loan);
    }
}