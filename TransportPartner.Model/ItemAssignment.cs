using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransportPartner.Models
{
    public class ItemAssignment
    {
        public int ItemId { get; set; }
        public int DeliveryId { get; set; }
        public Item Item { get; set; }
        public Delivery Delivery { get; set; }
    }
}
