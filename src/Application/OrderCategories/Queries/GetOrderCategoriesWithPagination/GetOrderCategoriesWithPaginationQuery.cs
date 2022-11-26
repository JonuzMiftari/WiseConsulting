using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Application.Common.Mappings;
using WiseConsulting.Application.Common.Models;

namespace WiseConsulting.Application.OrderCategories.Queries.GetOrderCategoriesWithPagination;

public record GetOrderCategoriesWithPaginationQuery : IRequest<PaginatedList<OrderCategoryVm>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetOrderCategoriesWithPaginationQueryHandler :
    IRequestHandler<GetOrderCategoriesWithPaginationQuery, PaginatedList<OrderCategoryVm>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<OrderCategoryVm>> Handle(
        GetOrderCategoriesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        //TODO: Remove test code with static data
        var items = new List<OrderCategoryVm>()
        {
            new OrderCategoryVm
            {
                Id = 1,
                Code = "19.02",
                Description = "Test description for 19.02!",
                Price = 19
            },
            new OrderCategoryVm
            {
                Id = 2,
                Code = "12.10",
                Description = "Test description for 12.10!",
                Price = 300
            }
        };

        var orderCategoryListWithPagination = new PaginatedList<OrderCategoryVm>(items, 5, 5, 5);

        return orderCategoryListWithPagination;

        //return await _context.OrderCategories
        //    .OrderBy(x => x.Id)
        //    .ProjectTo<OrderCategoryVm>(_mapper.ConfigurationProvider)
        //    .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}