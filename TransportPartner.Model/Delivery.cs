using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportPartner.Models
{
    public class Delivery 
    { 
        public int DeliveryId { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public string Address { get; set; }
        public Car CarUsed { get; set; }
        public bool Delivered { get; set; }
    }
}
