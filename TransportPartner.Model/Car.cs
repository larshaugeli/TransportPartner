using System.ComponentModel.DataAnnotations;

namespace TransportPartner.Models
{
    public class Car
    {
        [Key]
        public int RegNr { get; set; }
        public string CarModel { get; set; }
        public string Manufacturer { get; set; }
    }
}