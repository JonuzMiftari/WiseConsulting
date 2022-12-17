using Microsoft.EntityFrameworkCore;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Company> Companies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
