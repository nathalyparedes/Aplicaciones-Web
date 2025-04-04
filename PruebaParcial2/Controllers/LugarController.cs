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
    public class LugarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LugarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lugar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lugares.ToListAsync());
        }

        // GET: Lugar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lugar == null)
            {
                return NotFound();
            }

            return View(lugar);
        }

        // GET: Lugar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lugar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Capacidad")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lugar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lugar);
        }

        // GET: Lugar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugares.FindAsync(id);
            if (lugar == null)
            {
                return NotFound();
            }
            return View(lugar);
        }

        // POST: Lugar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Capacidad")] Lugar lugar)
        {
            if (id != lugar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lugar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LugarExists(lugar.Id))
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
            return View(lugar);
        }

        [Authorize(Roles = "Admin")]
        // GET: Lugar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lugar == null)
            {
                return NotFound();
            }

            return View(lugar);
        }

        // POST: Lugar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lugar = await _context.Lugares.FindAsync(id);
            if (lugar != null)
            {
                _context.Lugares.Remove(lugar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LugarExists(int id)
        {
            return _context.Lugares.Any(e => e.Id == id);
        }
    }
}
