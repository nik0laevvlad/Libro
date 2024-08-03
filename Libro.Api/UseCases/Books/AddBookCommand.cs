using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Repositories;
using Libro.Api.Models;
using MediatR;

namespace Libro.Api.UseCases.Books;

public class AddBookCommand(string title, string author) : IRequest<Guid>
{
    public string Title { get; } = title;
    public string Author { get; } = author;

    internal class Handler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<AddBookCommand, Guid>
    {
        public async Task<Guid> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            var book = Book.New(command.Title, command.Author);
            await bookRepository.AddAsync(book);
            await unitOfWork.CommitAsync();
            return book.Id;
        }
    }
}