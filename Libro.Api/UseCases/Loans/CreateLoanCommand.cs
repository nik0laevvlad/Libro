using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Identity;
using Libro.Api.Infrastructure.Repositories;
using Libro.Api.Models;
using MediatR;

namespace Libro.Api.UseCases.Loans;

public class CreateLoanCommand(Guid bookId, Guid userId) : IRequest<Guid>
{
    public Guid BookId { get; } = bookId;
    public Guid UserId { get; } = userId;

    internal class Handler(
        ILoanRepository loanRepository,
        IUserRepository userRepository,
        IBookRepository bookRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateLoanCommand, Guid>
    {
        public async Task<Guid> Handle(CreateLoanCommand command, CancellationToken cancellationToken)
        {
            var loan = Loan.New(command.BookId, command.UserId);
            var user = await userRepository.ByIdAsync(command.UserId);
            var book = await bookRepository.GetAsync(command.BookId);

            await loanRepository.AddAsync(loan);
            book.AddLoan(loan);
            user.AddLoan(loan);

            await unitOfWork.CommitAsync();
            return loan.Id;
        }
    }
}