using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TransportPartner.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryId { get; set; }

        [Display(Name = "Leveringsdato")] public DateTime DeliveryDate { get; set; }
        [Display(Name = "Adresse")] public string Address { get; set; }
        [Display(Name = "Bil brukt")] public string CarUsed { get; set; }
        [Display(Name = "Levert")] public bool Delivered { get; set; }
        [Display(Name = "Varer")] public string Item { get; set; }
        [Display(Name = "Ansatt")] public string Employee { get; set; }
    }
}
