using Libro.Api.Infrastructure.Identity;
using Libro.Api.UseCases.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers;

[Route("api/user")]
public class UserController(IMediator mediator, IUserRepository userRepository, IAuthPort authPort)
    : ControllerBase
{
    [HttpPost("register")]
    public async Task AddNewUserAsync([FromBody] CreateUserCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPost("login")]
    public async Task<string> Login([FromBody] LoginCommand command)
    {
        return await mediator.Send(command);
    }
}