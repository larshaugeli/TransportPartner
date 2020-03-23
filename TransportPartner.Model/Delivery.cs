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

        [DataType(DataType.Date)]
        [Display(Name = "Leveringsdato")] public DateTime DeliveryDate { get; set; }
        [Display(Name = "Adresse")] public string Address { get; set; }
        [Display(Name = "Postkode")] public int Postcode { get; set; }
        [Display(Name = "Firmabil")] public string CarUsed { get; set; }
        [Display(Name = "Levert")] public bool Delivered { get; set; }
        [Display(Name = "Varer")] public string Item { get; set; }
        [Display(Name = "Sjåfør")] public string Employee { get; set; }
    }
}
