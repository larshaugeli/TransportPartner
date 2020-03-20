using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TransportPartner.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Overview()
        {
            return View();
        }

        // GET: Delivery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Delivery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Delivery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Overview));
            }
            catch
            {
                return View();
            }
        }

        // GET: Delivery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Delivery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Overview));
            }
            catch
            {
                return View();
            }
        }

        // GET: Delivery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Delivery/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Overview));
            }
            catch
            {
                return View();
            }
        }
    }
}