using Microsoft.AspNetCore.Mvc;
using WiseConsulting.Application.Common.Models;
using WiseConsulting.Application.Companies.CreateCompany;
using WiseConsulting.Application.Companies.DeleteCompany;
using WiseConsulting.Application.Companies.Models;
using WiseConsulting.Application.Companies.Queries.GetCompaniesWithPagination;
using WiseConsulting.Application.Companies.UpdateCompany;

namespace WebUI.Controllers;
public class CompanyController : ApiControllerBase
{
    [HttpGet]
    public async Task<PaginatedList<CompanyDto>> Get() => await Mediator.Send(new GetCompaniesWithPaginationQuery());

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCompanyCommand command) => await Mediator.Send(command);

    [HttpPut("[action]")]
    public async Task<ActionResult> Update(int id, UpdateCompanyCommand command)
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
        await Mediator.Send(new DeleteCompanyCommand(id));

        return NoContent();
    }
}