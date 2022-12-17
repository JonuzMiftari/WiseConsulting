using MediatR;
using WiseConsulting.Application.Common.Exceptions;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Domain.Entities;
using WiseConsulting.Domain.Events;

namespace WiseConsulting.Application.Companies.DeleteCompany;
public record DeleteCompanyCommand(int Id) : IRequest;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCompanyCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Companies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Company), request.Id);
        }

        _context.Companies.Remove(entity);

        // TODO: add CompanyDeletedEvent
        // entity.AddDomainEvent(new CompanyDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}