using System.Linq;
using TransportPartner.Models;

namespace TransportPartner.Data
{
    // <summary>
    // This class initializes the database and fills items, employees and cars
    // <summary>
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
                    Name = "iPad Air (2019) 64 GB WiFi",
                    ProductId = "EXD334DNR56",
                    Developer = "Apple",
                    Genre = "Teknologi",
                    Price = 6190
                },
                new Item
                {
                    Name = "Acer Aspire 3 15,6\" bærbar PC",
                    ProductId = "TROS45FVFD",
                    Developer = "Acer",
                    Genre = "Teknologi",
                    Price = 7495
                },
                new Item
                {
                    Name = "Nikon Aculon 10x50 kikkert",
                    ProductId = "3DS59IGDJS",
                    Developer = "Nikon",
                    Genre = "Fritid",
                    Price = 1295
                },
                new Item
                {
                    Name = "Klassisk togbane bondegård",
                    ProductId = "3XD9TFIT55",
                    Developer = "Brio",
                    Genre = "Barneleker",
                    Price = 399
                },
                new Item
                {
                    Name = "Patchouli Lime duftlystol",
                    ProductId = "QAPND54N8ZS",
                    Developer = "Patchouli",
                    Genre = "Interiør",
                    Price = 129
                },
                new Item
                {
                    Name = "Corduroy gryteklut",
                    ProductId = "DUUYCDN543",
                    Developer = "Corduroy",
                    Genre = "Kjøkken",
                    Price = 79
                },
                new Item
                {
                    Name = "Speedcross 4 GTX terrengløpesko herre",
                    ProductId = "PO352NSIGR",
                    Developer = "Salomon",
                    Genre = "Sport",
                    Price = 999
                }
            );
            context.SaveChanges();

            context.Cars.AddRange(
                  new Car()
                  {
                      RegNr = "EL12843",
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
                  },
                  new Car()
                  {
                      RegNr = "AD28845",
                      CarModel = "Combo",
                      Manufacturer = "Opel"
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
                   FirstName = "Marit",
                   LastName = "Hjelmeseth"
               },
               new Employee()
               {
                   FirstName = "Bård",
                   LastName = "Duenes"
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
