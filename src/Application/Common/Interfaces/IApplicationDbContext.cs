using Microsoft.EntityFrameworkCore;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Company> Companies { get; }

    DbSet<OrderCategory> OrderCategories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
