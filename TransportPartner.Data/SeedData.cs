using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransportPartner.Models;

namespace TransportPartner.Data
{
    public class SeedData
    {
        public static void Initialize(TransportPartnerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any items.
            if (context.Items.Any())
            {
                return;   // DB has been seeded
            }

            context.Items.AddRange(
                new Item
                {
                    Name = "Tastatur",
                    Genre = "Teknologi",
                    Quantity = 2,
                    Price = 499
                },

                new Item
                {
                    Name = "Støvsuger",
                    Genre = "Teknologi",
                    Quantity = 5,
                    Price = 1299
                },

                new Item
                {
                    Name = "Stol",
                    Genre = "Interiør",
                    Quantity = 2,
                    Price = 999
                }
            );
            context.SaveChanges();

            context.Deliveries.AddRange(
                new Delivery()
                {
                    Address = "Gamle Kongevei 30",
                    DeliveryDate = new DateTime(05 / 29 / 2015),
                    Delivered = false
                }
            );
            context.SaveChanges();

            context.Cars.AddRange(
                  new Car()
                  {
                      RegNr = "EB12843",
                      CarModel = "Model X",
                      Manufacturer = "Tesla"
                  }
            );
            context.SaveChanges();

            context.Employees.AddRange(
               new Employee()
               {
                   EmployeeId = 1,
                   FirstName = "Ola",
                   LastName = "Nordmann"
               }
            );
            context.SaveChanges();
        }
    }
}
