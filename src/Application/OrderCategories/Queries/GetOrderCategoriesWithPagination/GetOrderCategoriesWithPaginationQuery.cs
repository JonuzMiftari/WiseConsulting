using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        // Query to get all Order Categories from database
        var categories = await _context.OrderCategories
            .AsNoTracking()
            .ProjectTo<OrderCategoryVm>(_mapper.ConfigurationProvider)
            .OrderBy(o => o.Code)
            .ToListAsync();

        var orderCategoryListWithPagination = new PaginatedList<OrderCategoryVm>(categories, 10, 1, 10);

        return orderCategoryListWithPagination;
   }
}