using Libro.Api.Infrastructure.Repositories;
using Libro.Api.Models;
using MediatR;

namespace Libro.Api.UseCases.Books;

public record GetBookByIdQuery(Guid Id) : IRequest<Book>
{
    internal class Handler(IBookRepository bookRepository) : IRequestHandler<GetBookByIdQuery, Book>
    {
        public async Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetAsync(query.Id);
            return book;
        }
    }
}