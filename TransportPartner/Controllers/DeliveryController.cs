using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportPartner.Models;

namespace TransportPartner.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public IActionResult Deliveries()
        {
            return View();
        }

        public IActionResult CreateDelivery()
        {
            return View();
        }
    }
}