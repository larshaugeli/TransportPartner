using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportPartner.Models
{
    // <summary>
    // This model contains variables and functions regarding items in the system
    // <summary>
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Modellnavn")]
        public string Name { get; set; }

        [Display(Name = "Produkt ID")]
        public string ProductId { get; set; }

        [Display(Name = "Produsent")]
        public string Developer { get; set; }

        [Display(Name = "Kategori")]
        public string Genre { get; set; }

        [Display(Name = "Pris (per enhet)")]
        public int Price { get; set; }

        [Display(Name = "Varenavn og Produkt ID")]
        public string NameAndProductId
        {
            get { return Name + ", " + ProductId; }
        }

        public ICollection<ItemAssignment> Deliveries { get; set; }
    }
}
