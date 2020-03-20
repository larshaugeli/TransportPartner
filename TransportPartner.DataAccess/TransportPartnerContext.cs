using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TransportPartner.Models;

namespace TransportPartner.DataAccess
{
    public class TransportPartnerContext : DbContext
    {
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Item> Items { get; set; }

        public TransportPartnerContext(DbContextOptions<TransportPartnerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

    public class TransportPartnerContextFactory : IDesignTimeDbContextFactory<TransportPartnerContext>
    {
        public TransportPartnerContext CreateDbContext(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "donau.hiof.no",
                InitialCatalog = "lhhaugel",
                UserID = "lhhaugel",
                Password = "ze59EYmH"
            };

            var connection = builder.ConnectionString.ToString();

            var optionsBuilder = new DbContextOptionsBuilder<TransportPartnerContext>().EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(connection, x => x.MigrationsAssembly("TransportPartner.DataAccess"));

            return new TransportPartnerContext(optionsBuilder.Options);
        }
    }
}
