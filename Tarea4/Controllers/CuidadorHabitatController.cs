using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea4.Data;
using Tarea4.Models;

namespace Tarea4.Controllers
{
    public class CuidadorHabitatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuidadorHabitatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CuidadorHabitat
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CuidadoresHabitats.Include(c => c.Cuidador).Include(c => c.Habitat);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CuidadorHabitat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidadorHabitat = await _context.CuidadoresHabitats
                .Include(c => c.Cuidador)
                .Include(c => c.Habitat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidadorHabitat == null)
            {
                return NotFound();
            }

            return View(cuidadorHabitat);
        }

        // GET: CuidadorHabitat/Create
        public IActionResult Create()
        {
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Apellido");
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "Id", "NombreHabitat");
            return View();
        }

        // POST: CuidadorHabitat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CuidadorId,HabitatId")] CuidadorHabitat cuidadorHabitat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuidadorHabitat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Apellido", cuidadorHabitat.CuidadorId);
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "Id", "NombreHabitat", cuidadorHabitat.HabitatId);
            return View(cuidadorHabitat);
        }

        // GET: CuidadorHabitat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidadorHabitat = await _context.CuidadoresHabitats.FindAsync(id);
            if (cuidadorHabitat == null)
            {
                return NotFound();
            }
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Apellido", cuidadorHabitat.CuidadorId);
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "Id", "NombreHabitat", cuidadorHabitat.HabitatId);
            return View(cuidadorHabitat);
        }

        // POST: CuidadorHabitat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CuidadorId,HabitatId")] CuidadorHabitat cuidadorHabitat)
        {
            if (id != cuidadorHabitat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuidadorHabitat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuidadorHabitatExists(cuidadorHabitat.Id))
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
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Apellido", cuidadorHabitat.CuidadorId);
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "Id", "NombreHabitat", cuidadorHabitat.HabitatId);
            return View(cuidadorHabitat);
        }

        // GET: CuidadorHabitat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidadorHabitat = await _context.CuidadoresHabitats
                .Include(c => c.Cuidador)
                .Include(c => c.Habitat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidadorHabitat == null)
            {
                return NotFound();
            }

            return View(cuidadorHabitat);
        }

        // POST: CuidadorHabitat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuidadorHabitat = await _context.CuidadoresHabitats.FindAsync(id);
            if (cuidadorHabitat != null)
            {
                _context.CuidadoresHabitats.Remove(cuidadorHabitat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuidadorHabitatExists(int id)
        {
            return _context.CuidadoresHabitats.Any(e => e.Id == id);
        }
    }
}
