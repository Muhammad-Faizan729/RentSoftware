
using Microsoft.EntityFrameworkCore;
using RentSoftware.Core.Entities;

namespace RentSoftware.Repository
{
    public class RentSoftwareDbContext : DbContext
    {
        public DbSet<Agent> Agents { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public RentSoftwareDbContext() : base()
        {
        }

        public RentSoftwareDbContext(DbContextOptions<RentSoftwareDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=RentSoftware; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agent>()
               .HasMany(a => a.Rents)
               .WithOne(r => r.Agent)
               .HasForeignKey(r => r.AgentId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Rents)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.Rents)
                .WithOne(r => r.Car)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
