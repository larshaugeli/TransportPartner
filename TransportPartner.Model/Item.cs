using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportPartner.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Modellnavn")]
        public string Name { get; set; }

        [Display(Name = "Produsent")]
        public string Developer { get; set; }

        [Display(Name = "Kategori")]
        public string Genre { get; set; }

        [Display(Name = "Pris (per enhet)")]
        public int Price { get; set; }

        public ICollection<ItemAssignment> Deliveries { get; set; }
    }
}
