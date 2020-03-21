using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;
using TransportPartner.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TransportPartner.Data
{
    public class TransportPartnerContext : DbContext
    {
        public TransportPartnerContext(DbContextOptions<TransportPartnerContext> options)
            : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Item> Item { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Delivery> Delivery { get; set; }
    }
}
