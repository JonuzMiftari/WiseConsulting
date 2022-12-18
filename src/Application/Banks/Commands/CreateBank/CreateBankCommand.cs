using MediatR;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Domain.Entities;
using WiseConsulting.Domain.Events;

namespace WiseConsulting.Application.Banks.Commands.CreateBank;

public record CreateBankCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
    public string Identifier { get; init; } = string.Empty;
}

public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBankCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBankCommand request, CancellationToken cancellationToken)
    {
        var entity = new Bank
        {
            Name = request.Name,
            Identifier = request.Identifier
        };

        entity.AddDomainEvent(new BankCreatedEvent(entity));

        _context.Banks.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}