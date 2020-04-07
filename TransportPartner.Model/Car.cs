using System.ComponentModel.DataAnnotations;

namespace TransportPartner.Models
{
    // <summary>
    // This model contains variables and functions regarding cars in the system
    // <summary>
    public class Car
    {
        [Key]
        [StringLength(7, MinimumLength = 2)]
        [Display(Name = "Registreringsnummer")]
        public string RegNr { get; set; }

        [Display(Name = "Model")]
        public string CarModel { get; set; }

        [Display(Name = "Bilmerke")]
        public string Manufacturer { get; set; }

        [Display(Name = "RegNr, Bil")]
        public string RegNrAndCar
        {
            get { return RegNr + ", " + Manufacturer + " " + CarModel; }
        }
    }
}