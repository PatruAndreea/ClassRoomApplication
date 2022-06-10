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
    public class ProfesorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profesors
        public async Task<IActionResult> Index()
        {
              return _context.Profesor != null ? 
                          View(await _context.Profesor.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Profesor'  is null.");
        }

        // GET: Profesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesor == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Profesors/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        // POST: Profesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesorId,ProfesorName,Password,Email,Telephone,PhotoURL")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Profesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesor == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Profesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesorId,ProfesorName,Password,Email,Telephone,PhotoURL")] Profesor profesor)
        {
            if (id != profesor.ProfesorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.ProfesorId))
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
            return View(profesor);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Profesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesor == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Profesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Profesor'  is null.");
            }
            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesor.Remove(profesor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
          return (_context.Profesor?.Any(e => e.ProfesorId == id)).GetValueOrDefault();
        }
    }
}
