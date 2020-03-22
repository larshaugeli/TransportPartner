using Microsoft.EntityFrameworkCore;
using TransportPartner.Models;

namespace TransportPartner.Data
{
    public class TransportPartnerContext : DbContext
    {
        public TransportPartnerContext(DbContextOptions<TransportPartnerContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Delivery>().ToTable("Delivery");
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }
    }
}
