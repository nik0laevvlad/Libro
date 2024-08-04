using Libro.Api.Infrastructure.Repositories;
using Libro.Api.Models;
using MediatR;

namespace Libro.Api.UseCases.Authors;

public record GetAuthorByIdQuery(Guid Id) : IRequest<Author>
{
    internal class Handler(IAuthorRepository authorRepository) : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        public async Task<Author> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
        {
            var author = await authorRepository.GetAsync(query.Id);
            return author;
        }
    }
}