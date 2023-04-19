using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoApi.Data;
using GeoData.Models;

namespace GeoApi.Controllers
{
    public class GeoDatasController : Controller
    {
        private readonly MvcDataContext _context;

        public GeoDatasController(MvcDataContext context)
        {
            _context = context;
        }

        // GET: GeoDatas
        public async Task<IActionResult> Index()
        {
              return _context.GeoData != null ? 
                          View(await _context.GeoData.ToListAsync()) :
                          Problem("Entity set 'MvcDataContext.GeoData'  is null.");
        }

        // GET: GeoDatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GeoData == null)
            {
                return NotFound();
            }

            var geoData = await _context.GeoData
                .FirstOrDefaultAsync(m => m.id == id);
            if (geoData == null)
            {
                return NotFound();
            }

            return View(geoData);
        }

        // GET: GeoDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeoDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ip,name,currency,currency_name,currency_symbol")] GeoData geoData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geoData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(geoData);
        }

        // GET: GeoDatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GeoData == null)
            {
                return NotFound();
            }

            var geoData = await _context.GeoData.FindAsync(id);
            if (geoData == null)
            {
                return NotFound();
            }
            return View(geoData);
        }

        // POST: GeoDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,ip,name,currency,currency_name,currency_symbol")] GeoData geoData)
        {
            if (id != geoData.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geoData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeoDataExists(geoData.id))
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
            return View(geoData);
        }

        // GET: GeoDatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GeoData == null)
            {
                return NotFound();
            }

            var geoData = await _context.GeoData
                .FirstOrDefaultAsync(m => m.id == id);
            if (geoData == null)
            {
                return NotFound();
            }

            return View(geoData);
        }

        // POST: GeoDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GeoData == null)
            {
                return Problem("Entity set 'MvcDataContext.GeoData'  is null.");
            }
            var geoData = await _context.GeoData.FindAsync(id);
            if (geoData != null)
            {
                _context.GeoData.Remove(geoData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeoDataExists(string id)
        {
          return (_context.GeoData?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
