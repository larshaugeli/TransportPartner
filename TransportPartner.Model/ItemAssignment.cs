using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransportPartner.Models
{
    // <summary>
    // This model is used to store data in a many-to-many relationship between Deliveries and Items
    // <summary>
    public class ItemAssignment
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ProductId { get; set; }
        public int DeliveryId { get; set; }
        public Item Item { get; set; }
        public Delivery Delivery { get; set; }
    }
}
