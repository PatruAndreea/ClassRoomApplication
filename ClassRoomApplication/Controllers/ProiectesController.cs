using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassRoomApplication.Data;
using ClassRoomApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClassRoomApplication.Controllers
{
    public class ProiectesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProiectesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proiectes
        public async Task<IActionResult> Index()
        {
              return _context.Proiecte != null ? 
                          View(await _context.Proiecte.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Proiecte'  is null.");
        }

        // GET: Proiectes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proiecte == null)
            {
                return NotFound();
            }

            var proiecte = await _context.Proiecte
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (proiecte == null)
            {
                return NotFound();
            }

            return View(proiecte);
        }

        [Authorize(Roles = "Profesor")]
        // GET: Proiectes/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Profesor")]
        // POST: Proiectes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Name,DateTime")] Proiecte proiecte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proiecte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proiecte);
        }

        [Authorize(Roles = "Profesor")]
        // GET: Proiectes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proiecte == null)
            {
                return NotFound();
            }

            var proiecte = await _context.Proiecte.FindAsync(id);
            if (proiecte == null)
            {
                return NotFound();
            }
            return View(proiecte);
        }

        [Authorize(Roles = "Profesor")]
        // POST: Proiectes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Name,DateTime")] Proiecte proiecte)
        {
            if (id != proiecte.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proiecte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProiecteExists(proiecte.ProjectId))
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
            return View(proiecte);
        }

        [Authorize(Roles = "Profesor")]
        // GET: Proiectes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proiecte == null)
            {
                return NotFound();
            }

            var proiecte = await _context.Proiecte
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (proiecte == null)
            {
                return NotFound();
            }

            return View(proiecte);
        }

        [Authorize(Roles = "Profesor")]
        // POST: Proiectes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proiecte == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Proiecte'  is null.");
            }
            var proiecte = await _context.Proiecte.FindAsync(id);
            if (proiecte != null)
            {
                _context.Proiecte.Remove(proiecte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProiecteExists(int id)
        {
          return (_context.Proiecte?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
