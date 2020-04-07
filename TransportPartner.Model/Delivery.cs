using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TransportPartner.Models
{
    // <summary>
    // This model contains variables and functions regarding delivieries in the system
    // <summary>
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Leveringsdato")] 
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Display(Name = "Adresse")] 
        public string Address { get; set; }

        [Required]
        [Display(Name = "Postkode")] 
        public int Postcode { get; set; }

        [Required]
        [Display(Name = "Firmabil")] 
        public string CarUsed { get; set; }

        [Display(Name = "Levert")] 
        public bool Delivered { get; set; }

        [Required]
        [Display(Name = "Sjåfør")] 
        public string Employee { get; set; }

        [Display(Name = "Varer")]
        public ICollection<ItemAssignment> Items { get; set; }
    }
}
