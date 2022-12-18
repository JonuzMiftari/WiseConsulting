using MediatR;
using WiseConsulting.Application.Common.Exceptions;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Domain.Entities;
using WiseConsulting.Domain.Events;

namespace WiseConsulting.Application.TodoItems.Commands.DeleteTodoItem;
public record DeleteBankCommand(int Id) : IRequest;

public class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBankCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Banks
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Bank), request.Id);
        }

        _context.Banks.Remove(entity);

        entity.AddDomainEvent(new BankDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
