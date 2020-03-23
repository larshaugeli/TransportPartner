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
                    Price = 499
                },

                new Item
                {
                    Name = "Støvsuger",
                    Genre = "Teknologi",
                    Price = 1299
                },

                new Item
                {
                    Name = "Stol",
                    Genre = "Interiør",
                    Price = 999
                }
            );
            context.SaveChanges();

            context.Cars.AddRange(
                  new Car()
                  {
                      RegNr = "EB12843",
                      CarModel = "Model X",
                      Manufacturer = "Tesla"
                  },
                  new Car()
                  {
                      RegNr = "EL34009",
                      CarModel = "Leaf",
                      Manufacturer = "Nissan"
                  },
                  new Car()
                  {
                      RegNr = "BA56312",
                      CarModel = "Kubistar",
                      Manufacturer = "Nissan"
                  }
            );
            context.SaveChanges();

            context.Employees.AddRange(
               new Employee()
               {
                   FirstName = "Ola",
                   LastName = "Nordmann",
               },
               new Employee()
               {
                    FirstName = "Trond",
                    LastName = "Hansen"
               },
               new Employee() 
               {
                   FirstName = "Kari",
                   LastName = "Jensen"
               });
            context.SaveChanges();
        }
    }
}
