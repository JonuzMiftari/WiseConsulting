using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Infrastructure.Persistence.Configurations;

public class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.Property(b => b.Name)
            .HasMaxLength(48)
            .IsRequired();

        builder.Property(b => b.Identifier)
            .HasMaxLength(3)           
            .IsRequired();
    }
}

