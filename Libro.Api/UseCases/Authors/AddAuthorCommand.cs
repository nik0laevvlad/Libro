using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Repositories;
using Libro.Api.Models;
using MediatR;

namespace Libro.Api.UseCases.Authors;

public class AddAuthorCommand(string firstName, string lastName) : IRequest<Guid>
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;

    internal class Handler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<AddAuthorCommand, Guid>
    {
        public async Task<Guid> Handle(AddAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = Author.New(command.FirstName, command.LastName);
            await authorRepository.AddAsync(author);
            await unitOfWork.CommitAsync();
            return author.Id;
        }
    }
}