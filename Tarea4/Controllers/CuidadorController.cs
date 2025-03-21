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

    public class CuidadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuidadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cuidador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuidadores.ToListAsync());
        }

        // GET: Cuidador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidador == null)
            {
                return NotFound();
            }

            return View(cuidador);
        }

        // GET: Cuidador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuidador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Telefono,Email")] Cuidador cuidador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuidador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuidador);
        }

        // GET: Cuidador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores.FindAsync(id);
            if (cuidador == null)
            {
                return NotFound();
            }
            return View(cuidador);
        }

        // POST: Cuidador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Telefono,Email")] Cuidador cuidador)
        {
            if (id != cuidador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuidador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuidadorExists(cuidador.Id))
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
            return View(cuidador);
        }

        // GET: Cuidador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidador == null)
            {
                return NotFound();
            }

            return View(cuidador);
        }

        // POST: Cuidador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuidador = await _context.Cuidadores.FindAsync(id);
            if (cuidador != null)
            {
                _context.Cuidadores.Remove(cuidador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuidadorExists(int id)
        {
            return _context.Cuidadores.Any(e => e.Id == id);
        }
    }
}
