using Libro.Api.Infrastructure.Repositories;
using Libro.Api.Models;
using MediatR;

namespace Libro.Api.UseCases.Authors;

public record GetAllAuthorsQuery : IRequest<Author[]>
{
    internal class Handler(IAuthorRepository authorRepository) : IRequestHandler<GetAllAuthorsQuery, Author[]>
    {
        public async Task<Author[]> Handle(GetAllAuthorsQuery query, CancellationToken cancellationToken)
        {
            var authors = await authorRepository.GetAllAsync();
            return authors;
        }
    }
}