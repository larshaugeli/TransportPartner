using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportPartner.Data;
using TransportPartner.Models;
using TransportPartner.Services;

namespace TransportPartner.Controllers
{
    public class DeliveriesController : Controller
    {
        private readonly TransportPartnerContext _context;
        readonly DeliveryService _service = new DeliveryService();

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

            // sorting
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
                 .Include(s => s.Items)
                 .AsNoTracking()
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
            ViewData["Item"] = new MultiSelectList(_context.Items, "Id", "NameAndProductId");
            ViewData["Employee"] = new SelectList(_context.Employees, "FullName", "FullName");
            return View();
        }

        // POST: Deliveries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryId,DeliveryDate,Address,Postcode,Delivered,CarUsed,Employee,Items")] Delivery delivery, int[] items)
        {
            if (items != null)
            {
                delivery.Items = new List<ItemAssignment>();
                foreach (var itemId in items)
                {
                    string itemName = _context.Items.Find(itemId).Name;
                    string productId = _context.Items.Find(itemId).ProductId;
                    var itemToAdd = new ItemAssignment() { ItemId = itemId, ItemName = itemName, ProductId = productId, DeliveryId = delivery.DeliveryId };
                    delivery.Items.Add(itemToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CarUsed"] = new SelectList(_context.Cars, "RegNr", "RegNrAndCar", delivery.CarUsed);
            ViewData["Items"] = new MultiSelectList(_context.Items, "Name", "NameAndProductId", delivery.Items);
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
            ViewData["Item"] = new MultiSelectList(_context.Items, "Id", "NameAndProductId");
            ViewData["Employee"] = new SelectList(_context.Employees, "FullName", "FullName");
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryId,DeliveryDate,Address,Postcode,Delivered,CarUsed,Items,Employee")] Delivery delivery, int[] items)
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
            ViewData["Items"] = new MultiSelectList(_context.Items, "Id", "NameAndProductId", delivery.Items);
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

        public IActionResult FillDatabase()
        {
            _service.FillDatabase(_context);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EmptyDatabase()
        {
            _context.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 0");
            _context.Database.ExecuteSqlRaw("truncate table [Delivery]");
            _context.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 1");
            
            return RedirectToAction(nameof(Index));
        }
    }
}
