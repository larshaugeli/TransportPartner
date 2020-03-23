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
                    DeliveryDate = new DateTime(02, 02, 2020),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(02, 02, 2020),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(02, 02, 2020),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(02, 02, 2020),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(02, 02, 2020),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(02, 02, 2020),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                });
        }
    }
}
