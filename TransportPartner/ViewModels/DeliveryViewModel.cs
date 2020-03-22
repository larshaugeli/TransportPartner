using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransportPartner.Data;
using TransportPartner.Models;

namespace TransportPartner.ViewModels
{
    public class DeliveryViewModel : PageModel
    {
        public Delivery Deliveries { get; set; }
        public List<SelectListItem> CarList { get; set; }
    }
}
