using System.ComponentModel.DataAnnotations;

namespace TransportPartner.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Display(Name = "Registreringsnummer")]
        public string RegNr { get; set; }
        [Display(Name = "Model")]
        public string CarModel { get; set; }
        [Display(Name = "Bilmerke")]
        public string Manufacturer { get; set; }
    }
}