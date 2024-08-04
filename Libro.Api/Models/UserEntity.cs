using Microsoft.EntityFrameworkCore;

namespace Libro.Api.Models;

[Index(nameof(Email), nameof(Username), IsUnique = true)]
public class UserEntity
{
    private readonly List<Loan> _loans = new();

    protected UserEntity()
    {
    }

    public IReadOnlyCollection<Loan> Loans => _loans.AsReadOnly();

    public Guid Id { get; protected set; }
    public string Username { get; protected set; } = null!;
    public string Email { get; protected set; } = null!;
    public string Password { get; protected set; } = null!;

    private UserEntity(Guid id, string username, string email, string password)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
    }

    internal void UpdateLoan(Loan updatedLoan)
    {
        var loan = _loans.Find(x => x.Id == updatedLoan.Id);
        if (loan == null)
        {
            throw new Exception("Loan not found in user");
        }

        if (loan.Status == LoanStatus.Approved)
        {
            throw new Exception("The loan has already been approved");
        }
        _loans.Remove(loan);
        _loans.Add(updatedLoan);
    }

    internal void AddLoan(Loan loan)
    {
        if (_loans.Any(x => x.Id == loan.Id))
        {
            throw new Exception("The loan has already been added");
        }
        _loans.Add(loan);
    }

    internal static UserEntity New(string username, string email, string password)
    {
        var user = new UserEntity(Guid.NewGuid(), username, email, password);
        return user;
    }
}