using Libro.Api.Infrastructure.Repositories;
using Libro.Api.Models;
using MediatR;

namespace Libro.Api.UseCases.Books;

public record GetAllBooksQuery : IRequest<Book[]>
{
    internal class Handler(IBookRepository bookRepository) : IRequestHandler<GetAllBooksQuery, Book[]>
    {
        public async Task<Book[]> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var books = await bookRepository.GetAllAsync();
            return books;
        }
    }
}