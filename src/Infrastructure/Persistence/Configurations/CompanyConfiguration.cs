using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Infrastructure.Persistence.Configurations;
public class CompanyConfiguration: IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(t => t.Code).IsRequired();
        builder.Property(t => t.Name)
            .HasMaxLength(64)
            .IsRequired();
        builder.Property(t => t.Address).HasMaxLength(128);
        builder.Property(t => t.City).HasMaxLength(48);
        builder.Property(t => t.Phone).HasMaxLength(16);
        builder.Property(t => t.Fax).HasMaxLength(16);
        builder.Property(t => t.Bank)
            .HasMaxLength(32).IsRequired();
        builder.Property(t => t.AccountNumber).HasMaxLength(16);
        builder.Property(t => t.IDNumber)
            .HasMaxLength(8).IsUnicode(false);
        builder.Property(t => t.RegistrationNumber)
            .HasMaxLength(10).IsUnicode(false);
        builder.Property(t => t.TaxNumber).HasMaxLength(16);
        builder.Property(t => t.ActivityCode)
            .HasMaxLength(7).IsUnicode(false);
        builder.Property(t => t.ContactPerson).HasMaxLength(32);
        builder.Property(t => t.Email).HasMaxLength(64);
        builder.Property(t => t.InvoiceSigningPerson).HasMaxLength(32);
    }
}
