using System.ComponentModel.DataAnnotations;
using Libro.Api.Infrastructure;
using Libro.Api.Infrastructure.Identity;
using Libro.Api.Models;
using MediatR;

namespace Libro.Api.UseCases.Identity;

public class CreateUserCommand(string username, string email, string password) : IRequest
{
    [Required]
    public string Username { get; } = username;

    [Required]
    public string Email { get; } = email;

    [Required]
    public string Password { get; } = password;

    internal class Handler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (await userRepository.IsUserExists(command.Email))
            {
                throw new Exception("User with this email already exists");
            }

            var user = UserEntity.New(command.Username, command.Email,
                BCrypt.Net.BCrypt.HashPassword(command.Password));

            await userRepository.AddAsync(user);
            await unitOfWork.CommitAsync();
        }
    }
}