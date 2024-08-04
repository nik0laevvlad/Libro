using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Identity;
using Libro.Api.Infrastructure.Repositories;
using MediatR;

namespace Libro.Api.UseCases.Loans;

public class ApproveLoanCommand(Guid loanId) : IRequest
{
    public Guid LoanId { get; } = loanId;

    internal class Handler(
        ILoanRepository loanRepository,
        IUserRepository userRepository,
        IBookRepository bookRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<ApproveLoanCommand>
    {
        public async Task Handle(ApproveLoanCommand command, CancellationToken cancellationToken)
        {
            var loan = await loanRepository.GetAsync(command.LoanId);
            var user = await userRepository.ByIdAsync(loan.UserId);
            var book = await bookRepository.GetAsync(loan.BookId);

            loan.Approve();
            book.UpdateLoan(loan);
            user.UpdateLoan(loan);

            await unitOfWork.CommitAsync();
        }
    }
}