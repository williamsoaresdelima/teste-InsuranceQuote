using InsuranceQuote.Domain.Entities;
using InsuranceQuote.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace InsuranceQuote.Infra.DataAccess
{
    public class ContextDb : DbContext
    {
        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Quote> Quote { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost; Database=InsuranceQuote; Username=admin; Password=admin; Port=5455");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new InsuranceConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclesConfiguration());
            modelBuilder.ApplyConfiguration(new QuoteConfiguration());      
        }
    }
}