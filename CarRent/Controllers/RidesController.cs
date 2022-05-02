#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRent.Models;

namespace CarRent.Controllers
{
    public class RidesController : Controller
    {
        private readonly RentingContext _context;

        public RidesController(RentingContext context)
        {
            _context = context;
        }

        // GET: Rides
        public async Task<IActionResult> Index()
        {
            var rentingContext = _context.Rides.Include(r => r.Car).Include(r => r.Reservation);
            return View(await rentingContext.ToListAsync());
        }

        // GET: Rides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides
                .Include(r => r.Car)
                .Include(r => r.Reservation)
                .FirstOrDefaultAsync(m => m.RideID == id);
            if (ride == null)
            {
                return NotFound();
            }

            return View(ride);
        }

        // GET: Rides/Create
        public IActionResult Create()
        {
            ViewData["CarsID"] = new SelectList(_context.Car, "CarsID", "CarsID");
            ViewData["ReservationID"] = new SelectList(_context.Reservation, "ReservationID", "ReservationID");
            return View();
        }

        // POST: Rides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RideID,CarsID,ReservationID")] Ride ride)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ride);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarsID"] = new SelectList(_context.Car, "CarsID", "CarsID", ride.CarsID);
            ViewData["ReservationID"] = new SelectList(_context.Reservation, "ReservationID", "ReservationID", ride.ReservationID);
            return View(ride);
        }

        // GET: Rides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides.FindAsync(id);
            if (ride == null)
            {
                return NotFound();
            }
            ViewData["CarsID"] = new SelectList(_context.Car, "CarsID", "CarsID", ride.CarsID);
            ViewData["ReservationID"] = new SelectList(_context.Reservation, "ReservationID", "ReservationID", ride.ReservationID);
            return View(ride);
        }

        // POST: Rides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RideID,CarsID,ReservationID")] Ride ride)
        {
            if (id != ride.RideID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ride);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RideExists(ride.RideID))
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
            ViewData["CarsID"] = new SelectList(_context.Car, "CarsID", "CarsID", ride.CarsID);
            ViewData["ReservationID"] = new SelectList(_context.Reservation, "ReservationID", "ReservationID", ride.ReservationID);
            return View(ride);
        }

        // GET: Rides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides
                .Include(r => r.Car)
                .Include(r => r.Reservation)
                .FirstOrDefaultAsync(m => m.RideID == id);
            if (ride == null)
            {
                return NotFound();
            }

            return View(ride);
        }

        // POST: Rides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ride = await _context.Rides.FindAsync(id);
            _context.Rides.Remove(ride);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RideExists(int id)
        {
            return _context.Rides.Any(e => e.RideID == id);
        }
    }
}
