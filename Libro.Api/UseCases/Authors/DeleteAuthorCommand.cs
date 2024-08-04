using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Repositories;
using MediatR;

namespace Libro.Api.UseCases.Authors;

public class DeleteAuthorCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;

    internal class Handler(IUnitOfWork unitOfWork, IAuthorRepository authorRepository) : IRequestHandler<DeleteAuthorCommand>
    {
        public async Task Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
        {
            await authorRepository.DeleteAsync(command.Id);
            await unitOfWork.CommitAsync();
        }
    }
}