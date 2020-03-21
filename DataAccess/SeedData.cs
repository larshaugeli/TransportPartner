using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransportPartner.Models;

namespace DataAccess
{
    public class SeedData
    {
        public static void Initialize(TransportPartnerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Items.Any())
            {
                return;   // DB has been seeded
            }


            context.Items.AddRange(
                new VisualStyleElement.Header.Item
                {
                    Name = "Tastatur",
                    Genre = "Teknologi",
                    Quantity = 2,
                },

                new VisualStyleElement.Header.Item
                {
                    Name = "Støvsuger",
                    Genre = "Teknologi",
                    Quantity = 5,
                },

                new VisualStyleElement.Header.Item
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
