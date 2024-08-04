using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Repositories;
using MediatR;

namespace Libro.Api.UseCases.Authors;

public class UpdateAuthorCommand(Guid id, string firstName, string lastName) : IRequest
{
    public Guid Id { get; } = id;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;

    internal class Handler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateAuthorCommand>
    {
        public async Task Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = await authorRepository.GetAsync(command.Id);
            author.Update(command.FirstName, command.LastName);

            await unitOfWork.CommitAsync();
        }
    }
}