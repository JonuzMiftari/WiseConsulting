using MediatR;
using Microsoft.AspNetCore.Mvc;
using WiseConsulting.Application.Banks.Commands.CreateBank;
using WiseConsulting.Application.Banks.Commands.UpdateBank;
using WiseConsulting.Application.Banks.Queries.GetBanks;
using WiseConsulting.Application.TodoItems.Commands.CreateTodoItem;
using WiseConsulting.Application.TodoItems.Commands.DeleteTodoItem;
using WiseConsulting.Application.TodoItems.Commands.UpdateTodoItem;
using WiseConsulting.Application.TodoItems.Commands.UpdateTodoItemDetail;
using WiseConsulting.Domain.Entities;

namespace WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class BankController : ControllerBase
{
    private ISender _mediator = null!;

    private ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [HttpGet]
    public async Task<IEnumerable<Bank>> Get() => await Mediator.Send(new GetBanksQuery());

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBankCommand command) => await Mediator.Send(command);

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateBankCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteBankCommand(id));

        return NoContent();
    }
}