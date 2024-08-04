using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Repositories;
using MediatR;

namespace Libro.Api.UseCases.Books;

public class DeleteBookCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;

    internal class Handler(IUnitOfWork unitOfWork, IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand>
    {
        public async Task Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            await bookRepository.DeleteAsync(command.Id);
            await unitOfWork.CommitAsync();
        }
    }
}