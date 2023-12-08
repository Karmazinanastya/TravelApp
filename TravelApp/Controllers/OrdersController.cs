using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApp.Context;
using TravelApp.Models;

namespace TravelApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ClientsController1
        public async Task<IActionResult> Index()
        {
            var orderViews = new List<OrderView>();

            var orders = await _context.Orders.ToListAsync();
            var clients = await _context.Clients.ToListAsync();
            var hotels = await _context.Hotels.ToListAsync();
            var tours = await _context.Tours.ToListAsync();

            foreach (var order in orders)
            {
                var client = clients.FirstOrDefault(x => x.Id == order.ClientId);
                var hotel = hotels.FirstOrDefault(x => x.Id == order.HotelId);
                var tour = tours.FirstOrDefault(x => x.Id == order.TourPackageID);
                orderViews.Add(new OrderView
                {
                    Id = order.Id,
                    Client = client.FirstName + " " + client.LastName,
                    Hotel = hotel.Name + " " + hotel.Location,
                    Tour = tour.Name + " " + tour.Description
                });
            }
            return View(orderViews);
        }

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET
        public async Task<ActionResult> Create()
        {
            var clients = await _context.Clients.ToListAsync();
            var hotels = await _context.Hotels.ToListAsync();
            var tours = await _context.Tours.ToListAsync();

            var model = new DropDownModel
            {
                сlients = clients,
                hotels = hotels,
                tourPackages = tours,
            };
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,ClientId,HotelId,TourPackageID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);

            var clients = await _context.Clients.ToListAsync();
            var hotels = await _context.Hotels.ToListAsync();
            var tours = await _context.Tours.ToListAsync();

            var model = new DropDownModel
            {
                OrderId = order.Id,
                сlients = clients,
                hotels = hotels,
                tourPackages = tours,
            };

            if (order == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ClientId,HotelId,TourPackageID")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
