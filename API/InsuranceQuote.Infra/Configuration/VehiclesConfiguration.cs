using InsuranceQuote.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceQuote.Infra.Configuration
{
    public class VehiclesConfiguration : IEntityTypeConfiguration<Vehicles>
    {
        public void Configure(EntityTypeBuilder<Vehicles> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.Price).IsRequired(true).HasColumnType("decimal(9,2)");
            builder.Property(p => p.Make).IsRequired(true).HasColumnType("varchar(50)");
            builder.Property(p => p.Model).IsRequired(true).HasColumnType("varchar(50)");
        }
    }
}