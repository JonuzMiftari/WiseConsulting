using MediatR;
using Microsoft.AspNetCore.Mvc;
using WiseConsulting.Application.Common.Models;
using WiseConsulting.Application.OrderCategories.Queries.GetOrderCategoriesWithPagination;

namespace WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderCategoryController : ControllerBase
{
    private ISender _mediator = null!;

    private ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [HttpGet]
    public async Task<ActionResult<PaginatedList<OrderCategoryVm>>> Get()
        => await Mediator.Send(new GetOrderCategoriesWithPaginationQuery());
}