using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Infrastructure.Persistence.Configurations;

public class OrderCategoryConfiguration : IEntityTypeConfiguration<OrderCategory>
{
    public void Configure(EntityTypeBuilder<OrderCategory> builder)
    {
        builder.Property(o => o.Code).IsRequired().HasMaxLength(10);
        builder.Property(o => o.Description).HasMaxLength(1000);
    }
}