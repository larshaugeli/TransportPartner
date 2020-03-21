using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TransportPartnerContext : DbContext
    {
        public TransportPartnerContext(DbContextOptions<TransportPartnerContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Delivery>().ToTable("Delivery");
        }
    }
}
