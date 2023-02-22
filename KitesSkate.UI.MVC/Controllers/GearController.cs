using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitsSkate.DATA.EF.Models;

namespace KitesSkate.UI.MVC.Controllers
{
    public class GearController : Controller
    {
        private readonly KitesSkateContext _context;

        public GearController(KitesSkateContext context)
        {
            _context = context;
        }

        // GET: Gear
        public async Task<IActionResult> Index()
        {
            var kitesSkateContext = _context.Gears.Include(g => g.Brand);
            return View(await kitesSkateContext.ToListAsync());
        }

        // GET: Gear/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears
                .Include(g => g.Brand)
                .FirstOrDefaultAsync(m => m.GearId == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // GET: Gear/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            return View();
        }

        // POST: Gear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GearId,GearName,GearPrice,GearDescription,GearInStock,GearOnOrder,GearAvailable,BrandId,ProductImage,GearTypeId")] Gear gear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", gear.BrandId);
            return View(gear);
        }

        // GET: Gear/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears.FindAsync(id);
            if (gear == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", gear.BrandId);
            return View(gear);
        }

        // POST: Gear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GearId,GearName,GearPrice,GearDescription,GearInStock,GearOnOrder,GearAvailable,BrandId,ProductImage,GearTypeId")] Gear gear)
        {
            if (id != gear.GearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearExists(gear.GearId))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", gear.BrandId);
            return View(gear);
        }

        // GET: Gear/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears
                .Include(g => g.Brand)
                .FirstOrDefaultAsync(m => m.GearId == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // POST: Gear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gears == null)
            {
                return Problem("Entity set 'KitesSkateContext.Gears'  is null.");
            }
            var gear = await _context.Gears.FindAsync(id);
            if (gear != null)
            {
                _context.Gears.Remove(gear);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GearExists(int id)
        {
          return _context.Gears.Any(e => e.GearId == id);
        }
    }
}
