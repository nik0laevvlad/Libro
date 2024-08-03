using Libro.Api.UseCases.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers;

[ApiController]
[Route("api/book")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Guid> AddAsync([FromBody] AddBookCommand command)
    {
        return await mediator.Send(command);
    }
}