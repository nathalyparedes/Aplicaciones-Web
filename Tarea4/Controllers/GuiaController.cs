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

    public class GuiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guias.ToListAsync());
        }

        // GET: Guia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guia = await _context.Guias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guia == null)
            {
                return NotFound();
            }

            return View(guia);
        }

        // GET: Guia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Telefono,Email,ExperienciaAnios")] Guia guia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guia);
        }

        // GET: Guia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guia = await _context.Guias.FindAsync(id);
            if (guia == null)
            {
                return NotFound();
            }
            return View(guia);
        }

        // POST: Guia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Telefono,Email,ExperienciaAnios")] Guia guia)
        {
            if (id != guia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuiaExists(guia.Id))
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
            return View(guia);
        }

        // GET: Guia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guia = await _context.Guias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guia == null)
            {
                return NotFound();
            }

            return View(guia);
        }

        // POST: Guia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guia = await _context.Guias.FindAsync(id);
            if (guia != null)
            {
                _context.Guias.Remove(guia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuiaExists(int id)
        {
            return _context.Guias.Any(e => e.Id == id);
        }
    }
}
