using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Application.Banks.Queries.GetBanks;

public record GetBanksQuery : IRequest<List<Bank>>;

public class GetBanksQueryHandler : IRequestHandler<GetBanksQuery, List<Bank>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBanksQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<List<Bank>> Handle(GetBanksQuery request, CancellationToken cancellationToken)
    {
        return await _context.Banks
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync(cancellationToken);
    }
}

