namespace Libro.Api.Models;

public class Book
{
    public Guid Id { get; protected set; }
    public string Title { get; protected set; }
    public string Author { get; protected set; }

    private readonly List<Loan> _loans = new();
    public IReadOnlyCollection<Loan> Loans => _loans.AsReadOnly();

    private Book(Guid id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    internal void AddLoan(Loan loan)
    {
        if (_loans.Any(x => x.Id == loan.Id))
        {
            throw new Exception("The loan has already been added");
        }
        _loans.Add(loan);
    }

    internal void UpdateLoan(Loan updatedLoan)
    {
        var loan = _loans.Find(x => x.Id == updatedLoan.Id);
        if (loan == null)
        {
            throw new Exception("Loan not found in book");
        }
        if (loan.Status == LoanStatus.Approved)
        {
            throw new Exception("The loan has already been approved");
        }
        _loans.Remove(loan);
        _loans.Add(updatedLoan);
    }

    internal void Update(string title, string author)
    {
        Title = title;
        Author = author;
    }

    internal static Book New(string title, string author)
    {
        var book = new Book(Guid.NewGuid(), title, author);
        return book;
    }
}