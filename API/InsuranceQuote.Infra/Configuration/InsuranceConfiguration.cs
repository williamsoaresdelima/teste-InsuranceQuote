using InsuranceQuote.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceQuote.Infra.Configuration
{
    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DocumentNumber).IsRequired(true).HasColumnType("varchar(11)");
            builder.Property(p => p.Name).IsRequired(true).HasColumnType("varchar(100)");
            builder.Property(p => p.Age).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.VehicleId).IsRequired(true).HasColumnType("int");

            builder.HasOne(x => x.Vehicle).WithMany(x => x.Insurances).HasForeignKey(x => x.VehicleId);
            builder.HasIndex(x => x.VehicleId).IsUnique(false);
        }
    }
}