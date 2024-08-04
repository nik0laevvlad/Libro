using System.ComponentModel.DataAnnotations;
using Libro.Api.Infrastructure.Identity;
using MediatR;

namespace Libro.Api.UseCases.Identity;

public class LoginCommand(string username, string password) : IRequest<string>
{
    [Required]
    public string Username { get; } = username;

    [Required]
    public string Password { get; } = password;

    internal class Handler(IUserRepository userRepository, ITokenService tokenService, IConfiguration configuration)
        : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var validUser = await userRepository.GetValidUserOrDefault(command.Username);

            if (validUser == null)
                throw new Exception("User not found");

            if (!BCrypt.Net.BCrypt.Verify(command.Password, validUser.Password))
            {
                throw new Exception("Incorrect password");
            }

            var generatedToken = tokenService.BuildToken(configuration["JwtAuth:Key"],
                configuration["JwtAuth:Issuer"], configuration["JwtAuth:Audience"], validUser);

            if (!tokenService.IsTokenValid(configuration["JwtAuth:Key"], configuration["JwtAuth:Issuer"],
                    configuration["JwtAuth:Audience"], generatedToken))
            {
                throw new Exception("Access denied");
            }

            return generatedToken;
        }
    }
}