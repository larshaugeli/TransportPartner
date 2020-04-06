using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransportPartner.Data;
using TransportPartner.Models;

namespace TransportPartner.Services
{
    public class DeliveryService
    {
        public void FillDatabase(TransportPartnerContext context)
        {
            context.Database.EnsureCreated();

            context.Deliveries.AddRange(
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 03, 26),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EL12843",
                    Delivered = false,
                    Employee = "Kari Jensen",
                    Items = new List<ItemAssignment>() { new ItemAssignment() { ItemId = 1, DeliveryId = 1, ItemName =  context.Items.Find(1).Name }, new ItemAssignment() { ItemId = 2, DeliveryId = 1, ItemName = context.Items.Find(2).Name } },
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 03, 26),
                    Address = "Opstadveien 45c",
                    Postcode = 1719,
                    CarUsed = "EL12843",
                    Delivered = false,
                    Employee = "Kari Jensen",
                    Items = new List<ItemAssignment>() { new ItemAssignment() { ItemId = 1, DeliveryId = 2, ItemName = context.Items.Find(1).Name }, new ItemAssignment() { ItemId = 2, DeliveryId = 2, ItemName = context.Items.Find(2).Name } }
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 03, 26),
                    Address = "Steinveien 34",
                    Postcode = 1719,
                    CarUsed = "EL12843",
                    Delivered = false,
                    Employee = "Kari Jensen",
                    Items = new List<ItemAssignment>() { new ItemAssignment() { ItemId = 1, DeliveryId = 3, ItemName = context.Items.Find(1).Name }, new ItemAssignment() { ItemId = 2, DeliveryId = 3, ItemName = context.Items.Find(2).Name } }
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 03, 27),
                    Address = "Konvallveien 67a",
                    Postcode = 1212,
                    CarUsed = "AD28845",
                    Delivered = false,
                    Employee = "Bård Duenes",
                    Items = new List<ItemAssignment>() { new ItemAssignment() { ItemId = 1, DeliveryId = 4, ItemName = context.Items.Find(1).Name }, new ItemAssignment() { ItemId = 2, DeliveryId = 4, ItemName = context.Items.Find(2).Name } }
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 03, 27),
                    Address = "Gamle Kongevei 102",
                    Postcode = 1712,
                    CarUsed = "AD28845",
                    Delivered = false,
                    Employee = "Bård Duenes",
                    Items = new List<ItemAssignment>() { new ItemAssignment() { ItemId = 1, DeliveryId = 5, ItemName = context.Items.Find(1).Name }, new ItemAssignment() { ItemId = 2, DeliveryId = 5, ItemName = context.Items.Find(2).Name } }
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 03, 28),
                    Address = "Johan Northugsvei 98",
                    Postcode = 1712,
                    CarUsed = "BA56312",
                    Delivered = false,
                    Employee = "Ola Nordmann",
                    Items = new List<ItemAssignment>() { new ItemAssignment() { ItemId = 1, DeliveryId = 6, ItemName = context.Items.Find(1).Name }, new ItemAssignment() { ItemId = 2, DeliveryId = 6, ItemName = context.Items.Find(2).Name } }
                });
            context.SaveChanges();
        }
    }
}
