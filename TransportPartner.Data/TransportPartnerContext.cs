using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TransportPartner.Models;

namespace TransportPartner.Data
{
    // <summary>
    // Database context class. Used for creating the tables
    // <summary>
    public class TransportPartnerContext : DbContext
    {
        public TransportPartnerContext(DbContextOptions<TransportPartnerContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ItemAssignment> ItemsAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Delivery>().ToTable("Delivery");
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<ItemAssignment>().ToTable("ItemAssignment");

            modelBuilder.Entity<ItemAssignment>().HasKey(i => new { i.DeliveryId, i.ItemId }); ;
        }
    }
}
