using Libro.Api.Models;
using Libro.Api.UseCases.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers;

[ApiController]
[Route("api/author")]
public class AuthorController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Guid> AddAsync([FromBody] AddAuthorCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpGet]
    public async Task<Author[]> GetAllAsync()
    {
        var query = new GetAllAuthorsQuery();
        return await mediator.Send(query);
    }

    [HttpGet("{id:guid}")]
    public async Task<Author> GetAsync(Guid id)
    {
        var query = new GetAuthorByIdQuery(id);
        return await mediator.Send(query);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await mediator.Send(new DeleteAuthorCommand(id));
    }

    [HttpPut]
    public async Task UpdateAsync([FromBody] UpdateAuthorCommand command)
    {
        await mediator.Send(command);
    }
}