using Libro.Api.UseCases.Loans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers;

[ApiController]
[Route("api/loan")]
public class LoanController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Guid> AddAsync([FromBody] CreateLoanCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    public async Task ApproveAsync([FromBody] ApproveLoanCommand command)
    {
        await mediator.Send(command);
    }
}