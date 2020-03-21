using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransportPartner.Models;

namespace TransportPartner.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TransportPartnerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TransportPartnerContext>>()))
            {
                // Look for any items.
                if (context.Item.Any())
                {
                    return; // DB has been seeded
                }

                context.Item.AddRange(
                    new Item
                    {
                        Name = "Tastatur",
                        Genre = "Teknologi",
                        Quantity = 2,
                    },

                    new Item
                    {
                        Name = "Støvsuger",
                        Genre = "Teknologi",
                        Quantity = 5,
                    },

                    new Item
                    {
                        Name = "Stol",
                        Genre = "Interiør",
                        Quantity = 2,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
