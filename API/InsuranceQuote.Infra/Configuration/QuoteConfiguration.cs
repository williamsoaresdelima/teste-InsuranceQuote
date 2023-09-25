using InsuranceQuote.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceQuote.Infra.Configuration
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.InsuranceId).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.RiskRate).IsRequired(true).HasColumnType("decimal(9,2)");
            builder.Property(p => p.RiskPremium).IsRequired(true).HasColumnType("decimal(9,2)");
            builder.Property(p => p.PurePrize).IsRequired(true).HasColumnType("decimal(9,2)");
            builder.Property(p => p.CommercialAward).IsRequired(true).HasColumnType("decimal(9,2)");

            builder.HasOne(x => x.Insurance).WithOne(x => x.Quote).HasForeignKey<Quote>(x => x.InsuranceId);
            builder.HasIndex(x => x.InsuranceId).IsUnique(false);
        }
    }
}