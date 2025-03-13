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
    public class AlimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alimentos.ToListAsync());
        }

        // GET: Alimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimentos
                .FirstOrDefaultAsync(m => m.IdAlimento == id);
            if (alimento == null)
            {
                return NotFound();
            }

            return View(alimento);
        }

        // GET: Alimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlimento,Nombre,Tipo,CantidadDisponible,FechaVencimiento")] Alimento alimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alimento);
        }

        // GET: Alimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimentos.FindAsync(id);
            if (alimento == null)
            {
                return NotFound();
            }
            return View(alimento);
        }

        // POST: Alimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlimento,Nombre,Tipo,CantidadDisponible,FechaVencimiento")] Alimento alimento)
        {
            if (id != alimento.IdAlimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlimentoExists(alimento.IdAlimento))
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
            return View(alimento);
        }

        // GET: Alimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimentos
                .FirstOrDefaultAsync(m => m.IdAlimento == id);
            if (alimento == null)
            {
                return NotFound();
            }

            return View(alimento);
        }

        // POST: Alimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alimento = await _context.Alimentos.FindAsync(id);
            if (alimento != null)
            {
                _context.Alimentos.Remove(alimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlimentoExists(int id)
        {
            return _context.Alimentos.Any(e => e.IdAlimento == id);
        }
    }
}
