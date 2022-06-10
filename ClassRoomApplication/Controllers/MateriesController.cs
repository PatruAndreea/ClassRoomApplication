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
    
    public class MateriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Materies
        public async Task<IActionResult> Index()
        {
              return _context.Materie != null ? 
                          View(await _context.Materie.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Materie'  is null.");
        }

        // GET: Materies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materie == null)
            {
                return NotFound();
            }

            var materie = await _context.Materie
                .FirstOrDefaultAsync(m => m.MaterieId == id);
            if (materie == null)
            {
                return NotFound();
            }

            return View(materie);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Materies/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        // POST: Materies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterieId,Name,Semester,ProjectId")] Materie materie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materie);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Materies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materie == null)
            {
                return NotFound();
            }

            var materie = await _context.Materie.FindAsync(id);
            if (materie == null)
            {
                return NotFound();
            }
            return View(materie);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Materies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterieId,Name,Semester,ProjectId")] Materie materie)
        {
            if (id != materie.MaterieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterieExists(materie.MaterieId))
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
            return View(materie);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Materies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materie == null)
            {
                return NotFound();
            }

            var materie = await _context.Materie
                .FirstOrDefaultAsync(m => m.MaterieId == id);
            if (materie == null)
            {
                return NotFound();
            }

            return View(materie);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Materies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Materie'  is null.");
            }
            var materie = await _context.Materie.FindAsync(id);
            if (materie != null)
            {
                _context.Materie.Remove(materie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterieExists(int id)
        {
          return (_context.Materie?.Any(e => e.MaterieId == id)).GetValueOrDefault();
        }
    }
}
