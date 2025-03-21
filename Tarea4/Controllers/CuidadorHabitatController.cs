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
        public async Task<IActionResult> Details(int? cuidadorId, int? habitatId)
        {
            if (cuidadorId == null || habitatId == null)
            {
                return NotFound();
            }

            var cuidadorHabitat = await _context.CuidadoresHabitats
                .Include(ch => ch.Cuidador)
                .Include(ch => ch.Habitat)
                .FirstOrDefaultAsync(ch => ch.CuidadorId == cuidadorId && ch.HabitatId == habitatId);

            if (cuidadorHabitat == null)
            {
                return NotFound();
            }

            return View(cuidadorHabitat);
        }

        // GET: CuidadorHabitat/Create
        public IActionResult Create()
        {
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Nombre"); 
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "Id", "NombreHabitat");   
            return View();
        }

        // POST: CuidadorHabitat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("CuidadorId,HabitatId")] CuidadorHabitat cuidadorHabitat)
{
    Console.WriteLine($"CuidadorId: {cuidadorHabitat.CuidadorId}, HabitatId: {cuidadorHabitat.HabitatId}");

    if (ModelState.IsValid)
    {
        try
        {
            Console.WriteLine("Intentando guardar en la base de datos...");
            _context.Add(cuidadorHabitat);
            await _context.SaveChangesAsync();
            Console.WriteLine("Registro guardado exitosamente.");
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("ModelState no es válido.");
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine($"Error: {error.ErrorMessage}");
        }
    }

    ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Nombre", cuidadorHabitat.CuidadorId);
    ViewData["HabitatId"] = new SelectList(_context.Habitats, "Id", "NombreHabitat", cuidadorHabitat.HabitatId);
    return View(cuidadorHabitat);
}
        // GET: CuidadorHabitat/Edit/5
        public async Task<IActionResult> Edit(int? cuidadorId, int? habitatId)
            {
                if (cuidadorId == null || habitatId == null)
                {
                    return NotFound();
                }

                var cuidadorHabitat = await _context.CuidadoresHabitats
                    .FirstOrDefaultAsync(ch => ch.CuidadorId == cuidadorId && ch.HabitatId == habitatId);

                if (cuidadorHabitat == null)
                {
                    return NotFound();
                }

                ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Nombre", cuidadorHabitat.CuidadorId);
                ViewData["HabitatId"] = new SelectList(_context.Habitats, "Id", "NombreHabitat", cuidadorHabitat.HabitatId);
                return View(cuidadorHabitat);
            }

        // POST: CuidadorHabitat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int cuidadorId, int habitatId, [Bind("CuidadorId,HabitatId")] CuidadorHabitat cuidadorHabitat)
        {
            if (cuidadorId != cuidadorHabitat.CuidadorId || habitatId != cuidadorHabitat.HabitatId)
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
                    
                    if (!CuidadorHabitatExists(cuidadorHabitat.CuidadorId, cuidadorHabitat.HabitatId))
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

            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Id", cuidadorHabitat.CuidadorId);
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "Id", "Id", cuidadorHabitat.HabitatId);
            return View(cuidadorHabitat);
        }

        // GET: CuidadorHabitat/Delete/5
       public async Task<IActionResult> Delete(int? cuidadorId, int? habitatId)
        {
            if (cuidadorId == null || habitatId == null)
            {
                return NotFound();
            }

            var cuidadorHabitat = await _context.CuidadoresHabitats
                .Include(ch => ch.Cuidador)
                .Include(ch => ch.Habitat)
                .FirstOrDefaultAsync(ch => ch.CuidadorId == cuidadorId && ch.HabitatId == habitatId);

            if (cuidadorHabitat == null)
            {
                return NotFound();
            }

            return View(cuidadorHabitat);
        }

        // POST: CuidadorHabitat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int cuidadorId, int habitatId)
        {
            var cuidadorHabitat = await _context.CuidadoresHabitats
                .FirstOrDefaultAsync(ch => ch.CuidadorId == cuidadorId && ch.HabitatId == habitatId);

            if (cuidadorHabitat != null)
            {
                _context.CuidadoresHabitats.Remove(cuidadorHabitat);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CuidadorHabitatExists(int cuidadorId, int habitatId)
    {
        return _context.CuidadoresHabitats.Any(ch => ch.CuidadorId == cuidadorId && ch.HabitatId == habitatId);
    }
    }
}
