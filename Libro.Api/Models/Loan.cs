namespace Libro.Api.Models;

public class Loan
{
    public Guid Id { get; private set; }
    public Guid BookId { get; private set; }
    public Guid UserId { get; private set; }
    public LoanStatus Status { get; private set; }
    public DateTime? FromDate { get; private set; }
    public DateTime? ToDate { get; private set; }

    private Loan(Guid id, Guid bookId, Guid userId, LoanStatus status, DateTime? fromDate, DateTime? toDate)
    {
        Id = id;
        BookId = bookId;
        UserId = userId;
        Status = status;
        FromDate = fromDate;
        ToDate = toDate;
    }

    internal void Approve()
    {
        ChangeStatus(LoanStatus.Approved);
        FromDate = DateTime.Now;
        ToDate = DateTime.Now.AddDays(7);
    }

    internal void ChangeStatus(LoanStatus status)
    {
        Status = status;
    }

    internal static Loan New(Guid bookId, Guid userId)
    {
        var loan = new Loan(Guid.NewGuid(), bookId, userId, LoanStatus.Pending, null, null);
        return loan;
    }
}