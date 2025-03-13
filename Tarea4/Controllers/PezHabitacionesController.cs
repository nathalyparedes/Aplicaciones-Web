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
    public class PezHabitacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PezHabitacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PezHabitaciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PecesHabitaciones.Include(p => p.Habitacion).Include(p => p.Pez);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PezHabitaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pezHabitacion = await _context.PecesHabitaciones
                .Include(p => p.Habitacion)
                .Include(p => p.Pez)
                .FirstOrDefaultAsync(m => m.IdPez == id);
            if (pezHabitacion == null)
            {
                return NotFound();
            }

            return View(pezHabitacion);
        }

        // GET: PezHabitaciones/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre");
            ViewData["IdPez"] = new SelectList(_context.Peces, "IdPez", "NombreComun");
            return View();
        }

        // POST: PezHabitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPez,IdHabitacion,FechaIngreso,FechaSalida")] PezHabitacion pezHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pezHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre", pezHabitacion.IdHabitacion);
            ViewData["IdPez"] = new SelectList(_context.Peces, "IdPez", "NombreComun", pezHabitacion.IdPez);
            return View(pezHabitacion);
        }

        // GET: PezHabitaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pezHabitacion = await _context.PecesHabitaciones.FindAsync(id);
            if (pezHabitacion == null)
            {
                return NotFound();
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre", pezHabitacion.IdHabitacion);
            ViewData["IdPez"] = new SelectList(_context.Peces, "IdPez", "NombreComun", pezHabitacion.IdPez);
            return View(pezHabitacion);
        }

        // POST: PezHabitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPez,IdHabitacion,FechaIngreso,FechaSalida")] PezHabitacion pezHabitacion)
        {
            if (id != pezHabitacion.IdPez)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pezHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PezHabitacionExists(pezHabitacion.IdPez))
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
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre", pezHabitacion.IdHabitacion);
            ViewData["IdPez"] = new SelectList(_context.Peces, "IdPez", "NombreComun", pezHabitacion.IdPez);
            return View(pezHabitacion);
        }

        // GET: PezHabitaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pezHabitacion = await _context.PecesHabitaciones
                .Include(p => p.Habitacion)
                .Include(p => p.Pez)
                .FirstOrDefaultAsync(m => m.IdPez == id);
            if (pezHabitacion == null)
            {
                return NotFound();
            }

            return View(pezHabitacion);
        }

        // POST: PezHabitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pezHabitacion = await _context.PecesHabitaciones.FindAsync(id);
            if (pezHabitacion != null)
            {
                _context.PecesHabitaciones.Remove(pezHabitacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PezHabitacionExists(int id)
        {
            return _context.PecesHabitaciones.Any(e => e.IdPez == id);
        }
    }
}
