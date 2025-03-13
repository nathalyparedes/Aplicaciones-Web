using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea4.Data;
using Tarea4.Models;
using Microsoft.AspNetCore.Authorization;


namespace Tarea4.Controllers
{
     [Authorize]
    public class AlimentacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlimentacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alimentacion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alimentaciones.Include(a => a.Alimento).Include(a => a.Pez);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alimentacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimentacion = await _context.Alimentaciones
                .Include(a => a.Alimento)
                .Include(a => a.Pez)
                .FirstOrDefaultAsync(m => m.IdAlimentacion == id);
            if (alimentacion == null)
            {
                return NotFound();
            }

            return View(alimentacion);
        }

        // GET: Alimentacion/Create
        public IActionResult Create()
        {
            ViewData["IdAlimento"] = new SelectList(_context.Alimentos, "IdAlimento", "Nombre");
            ViewData["IdPez"] = new SelectList(_context.Peces, "IdPez", "NombreComun");
            return View();
        }

        // POST: Alimentacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlimentacion,IdPez,IdAlimento,Cantidad,FechaAlimentacion")] Alimentacion alimentacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alimentacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlimento"] = new SelectList(_context.Alimentos, "IdAlimento", "Nombre", alimentacion.IdAlimento);
            ViewData["IdPez"] = new SelectList(_context.Peces, "IdPez", "NombreComun", alimentacion.IdPez);
            return View(alimentacion);
        }

        // GET: Alimentacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimentacion = await _context.Alimentaciones.FindAsync(id);
            if (alimentacion == null)
            {
                return NotFound();
            }
            ViewData["IdAlimento"] = new SelectList(_context.Alimentos, "IdAlimento", "Nombre", alimentacion.IdAlimento);
            ViewData["IdPez"] = new SelectList(_context.Peces, "IdPez", "NombreComun", alimentacion.IdPez);
            return View(alimentacion);
        }

        // POST: Alimentacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlimentacion,IdPez,IdAlimento,Cantidad,FechaAlimentacion")] Alimentacion alimentacion)
        {
            if (id != alimentacion.IdAlimentacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alimentacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlimentacionExists(alimentacion.IdAlimentacion))
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
            ViewData["IdAlimento"] = new SelectList(_context.Alimentos, "IdAlimento", "Nombre", alimentacion.IdAlimento);
            ViewData["IdPez"] = new SelectList(_context.Peces, "IdPez", "NombreComun", alimentacion.IdPez);
            return View(alimentacion);
        }

        // GET: Alimentacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimentacion = await _context.Alimentaciones
                .Include(a => a.Alimento)
                .Include(a => a.Pez)
                .FirstOrDefaultAsync(m => m.IdAlimentacion == id);
            if (alimentacion == null)
            {
                return NotFound();
            }

            return View(alimentacion);
        }

        // POST: Alimentacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alimentacion = await _context.Alimentaciones.FindAsync(id);
            if (alimentacion != null)
            {
                _context.Alimentaciones.Remove(alimentacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlimentacionExists(int id)
        {
            return _context.Alimentaciones.Any(e => e.IdAlimentacion == id);
        }
    }
}
