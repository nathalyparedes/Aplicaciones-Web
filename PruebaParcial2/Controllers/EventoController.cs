using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaParcial2.Data;
using PruebaParcial2.Models;
using Microsoft.AspNetCore.Authorization;

namespace PruebaParcial2.Controllers
{
    [Authorize(Roles = "Admin,Escritor")]
    public class EventoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evento
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Eventos.Include(e => e.Lugar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Lugar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            ViewData["LugarId"] = new SelectList(_context.Lugares, "Id", "Direccion");
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Hora,LugarId")] Evento evento)
{
    Console.WriteLine("Entró al método Create (POST)");
    Console.WriteLine($"Nombre: {evento.Nombre}, Fecha: {evento.Fecha}, Hora: {evento.Hora}, LugarId: {evento.LugarId}");

    if (ModelState.IsValid)
    {
        Console.WriteLine("ModelState es válido");
        _context.Add(evento);
        await _context.SaveChangesAsync();
        Console.WriteLine("Evento guardado correctamente");
        return RedirectToAction(nameof(Index));
    }

    Console.WriteLine("ModelState no es válido");
    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
    {
        Console.WriteLine($"Error: {error.ErrorMessage}");
    }

    ViewData["LugarId"] = new SelectList(_context.Lugares, "Id", "Direccion", evento.LugarId);
    return View(evento);
}

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["LugarId"] = new SelectList(_context.Lugares, "Id", "Direccion", evento.LugarId);
            return View(evento);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,Hora,LugarId")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            ViewData["LugarId"] = new SelectList(_context.Lugares, "Id", "Direccion", evento.LugarId);
            return View(evento);
        }

         [Authorize(Roles = "Admin")]
        // GET: Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Lugar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
