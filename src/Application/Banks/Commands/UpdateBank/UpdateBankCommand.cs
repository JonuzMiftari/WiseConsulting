using MediatR;
using WiseConsulting.Application.Common.Exceptions;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Domain.Entities;
using WiseConsulting.Domain.Events;

namespace WiseConsulting.Application.Banks.Commands.UpdateBank;

public record UpdateBankCommand(int Id, Bank bank) : IRequest;

public class UpdateBankCommandHandler : IRequestHandler<UpdateBankCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBankCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Banks
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if(entity == null)
        {
            throw new NotFoundException(nameof(Bank), request.Id);
        }

        entity.AddDomainEvent(new BankUpdatedEvent(request.bank));

        return Unit.Value;
    }
}

