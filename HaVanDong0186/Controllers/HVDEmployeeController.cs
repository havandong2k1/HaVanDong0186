using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HaVanDong0186.Models;
using MvcMovie.Data;

namespace HaVanDong0186.Controllers
{
    public class HVDEmployeeController : Controller
    {
        private readonly MvcMovieContext _context;

        public HVDEmployeeController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: HVDEmployee
        public async Task<IActionResult> Index()
        {
              return _context.HVDEmployee != null ? 
                          View(await _context.HVDEmployee.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.HVDEmployee'  is null.");
        }

        // GET: HVDEmployee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HVDEmployee == null)
            {
                return NotFound();
            }

            var hVDEmployee = await _context.HVDEmployee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (hVDEmployee == null)
            {
                return NotFound();
            }

            return View(hVDEmployee);
        }

        // GET: HVDEmployee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HVDEmployee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeName,NgaySinh")] HVDEmployee hVDEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hVDEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hVDEmployee);
        }

        // GET: HVDEmployee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HVDEmployee == null)
            {
                return NotFound();
            }

            var hVDEmployee = await _context.HVDEmployee.FindAsync(id);
            if (hVDEmployee == null)
            {
                return NotFound();
            }
            return View(hVDEmployee);
        }

        // POST: HVDEmployee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("EmployeeID,EmployeeName,NgaySinh")] HVDEmployee hVDEmployee)
        {
            if (id != hVDEmployee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hVDEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HVDEmployeeExists(hVDEmployee.EmployeeID))
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
            return View(hVDEmployee);
        }

        // GET: HVDEmployee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HVDEmployee == null)
            {
                return NotFound();
            }

            var hVDEmployee = await _context.HVDEmployee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (hVDEmployee == null)
            {
                return NotFound();
            }

            return View(hVDEmployee);
        }

        // POST: HVDEmployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.HVDEmployee == null)
            {
                return Problem("Entity set 'MvcMovieContext.HVDEmployee'  is null.");
            }
            var hVDEmployee = await _context.HVDEmployee.FindAsync(id);
            if (hVDEmployee != null)
            {
                _context.HVDEmployee.Remove(hVDEmployee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HVDEmployeeExists(int? id)
        {
          return (_context.HVDEmployee?.Any(e => e.EmployeeID == id)).GetValueOrDefault();
        }
    }
}
