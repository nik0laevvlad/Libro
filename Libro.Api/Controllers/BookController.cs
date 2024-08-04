using Libro.Api.Models;
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

    [HttpGet]
    public async Task<Book[]> GetAllAsync()
    {
        var query = new GetAllBooksQuery();
        return await mediator.Send(query);
    }

    [HttpGet("{id:guid}")]
    public async Task<Book> GetAsync(Guid id)
    {
        var query = new GetBookByIdQuery(id);
        return await mediator.Send(query);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await mediator.Send(new DeleteBookCommand(id));
    }

    [HttpPut]
    public async Task UpdateAsync([FromBody] UpdateBookCommand command)
    {
        await mediator.Send(command);
    }
}