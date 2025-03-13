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
    public class PezController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PezController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pez
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peces.ToListAsync());
        }

        // GET: Pez/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pez = await _context.Peces
                .FirstOrDefaultAsync(m => m.IdPez == id);
            if (pez == null)
            {
                return NotFound();
            }

            return View(pez);
        }

        // GET: Pez/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pez/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPez,NombreComun,NombreCientifico,Especie,FechaIngreso,Cantidad")] Pez pez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pez);
        }

        // GET: Pez/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pez = await _context.Peces.FindAsync(id);
            if (pez == null)
            {
                return NotFound();
            }
            return View(pez);
        }

        // POST: Pez/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPez,NombreComun,NombreCientifico,Especie,FechaIngreso,Cantidad")] Pez pez)
        {
            if (id != pez.IdPez)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PezExists(pez.IdPez))
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
            return View(pez);
        }

        // GET: Pez/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pez = await _context.Peces
                .FirstOrDefaultAsync(m => m.IdPez == id);
            if (pez == null)
            {
                return NotFound();
            }

            return View(pez);
        }

        // POST: Pez/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pez = await _context.Peces.FindAsync(id);
            if (pez != null)
            {
                _context.Peces.Remove(pez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PezExists(int id)
        {
            return _context.Peces.Any(e => e.IdPez == id);
        }
    }
}
