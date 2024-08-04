using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Repositories;
using MediatR;

namespace Libro.Api.UseCases.Books;

public class UpdateBookCommand(Guid id, string title, string author) : IRequest
{
    public Guid Id { get; } = id;
    public string Title { get; } = title;
    public string Author { get; } = author;

    internal class Handler(IBookRepository bookRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateBookCommand>
    {
        public async Task Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetAsync(command.Id);
            book.Update(command.Title, command.Author);

            await unitOfWork.CommitAsync();
        }
    }
}