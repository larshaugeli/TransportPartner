using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportPartner.Models
{
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