using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TransportPartner.Data;
using TransportPartner.Models;
using TransportPartner.Services;
using TransportPartner.ViewModels;

namespace TransportPartner.Controllers
{
    public class DeliveriesController : Controller
    {
        private readonly TransportPartnerContext _context;

        public DeliveriesController(TransportPartnerContext context)
        {
            _context = context;
        }

        // GET: Deliveries
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["RegNrSortParm"] = String.IsNullOrEmpty(sortOrder) ? "regnr_desc" : "regnr";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var deliveries = from d in _context.Deliveries
                select d;
            switch (sortOrder)
            {
                case "regnr":
                    deliveries = deliveries.OrderBy(d => d.CarUsed);
                    break;
                case "regnr_desc":
                    deliveries = deliveries.OrderByDescending(d => d.CarUsed);
                    break;
                case "Date":
                    deliveries = deliveries.OrderBy(d => d.DeliveryDate);
                    break;
                case "date_desc":
                    deliveries = deliveries.OrderByDescending(d => d.DeliveryDate);
                    break;
                default:
                    deliveries = deliveries.OrderBy(d => d.DeliveryDate);
                    break;
            }

            return View(await deliveries.AsNoTracking().ToListAsync());
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .FirstOrDefaultAsync(m => m.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            ViewData["CarUsed"] = new SelectList(_context.Cars, "RegNr", "RegNrAndCar");
            ViewData["Item"] = new SelectList(_context.Items, "Name", "Name");
            ViewData["Employee"] = new SelectList(_context.Employees, "FullName", "FullName");
            return View();
        }

        // POST: Deliveries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryId,DeliveryDate,Address,Postcode,Delivered,CarUsed,Item,Employee")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CarUsed"] = new SelectList(_context.Cars, "RegNr", "RegNrAndCar", delivery.CarUsed);
            ViewData["Item"] = new SelectList(_context.Items, "Name", "Name", delivery.Item);
            ViewData["Employee"] = new SelectList(_context.Employees, "FullName", "FullName", delivery.Employee);
            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            ViewData["CarUsed"] = new SelectList(_context.Cars, "RegNr", "RegNrAndCar");
            ViewData["Item"] = new SelectList(_context.Items, "Name", "Name");
            ViewData["Employee"] = new SelectList(_context.Employees, "FullName", "FullName");
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryId,DeliveryDate,Address,Postcode,Delivered,CarUsed,Item,Employee")] Delivery delivery)
        {
            if (id != delivery.DeliveryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryExists(delivery.DeliveryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CarUsed"] = new SelectList(_context.Cars, "RegNr", "RegNrAndCar", delivery.CarUsed);
            ViewData["Item"] = new SelectList(_context.Items, "Name", "Name", delivery.Item);
            ViewData["Employee"] = new SelectList(_context.Employees, "FullName", "FullName", delivery.Employee);
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .FirstOrDefaultAsync(m => m.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryExists(int id)
        {
            return _context.Deliveries.Any(e => e.DeliveryId == id);
        }

        public RedirectToActionResult FillDatabase()
        {
            _context.Database.EnsureCreated();

            _context.Deliveries.AddRange(
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 02, 20),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 02, 20),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 02, 20),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 02, 20),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 02, 20),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                },
                new Delivery
                {
                    DeliveryDate = new DateTime(2020, 02, 20),
                    Address = "Stevneveien 12",
                    Postcode = 1719,
                    CarUsed = "EB20340",
                    Delivered = false,
                    Employee = "Kari Jensen",
                });
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EmptyDatabase()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Delivery]");
            return RedirectToAction(nameof(Index));
        }
    }
}
