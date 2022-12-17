using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Application.Common.Mappings;
using WiseConsulting.Application.Common.Models;
using WiseConsulting.Application.Companies.Models;

namespace WiseConsulting.Application.Companies.Queries.GetCompaniesWithPagination;
public class GetCompaniesWithPaginationQuery : IRequest<PaginatedList<CompanyDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

class GetCompaniesWithPaginationQueryHandler: IRequestHandler<GetCompaniesWithPaginationQuery, PaginatedList<CompanyDto>>
{
    #region Fields and Constructor
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCompaniesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    public async Task<PaginatedList<CompanyDto>> Handle(GetCompaniesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .OrderBy(x => x.Name)
            .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}