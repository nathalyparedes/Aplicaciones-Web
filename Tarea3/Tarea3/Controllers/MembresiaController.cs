using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea3.Data;
using Tarea3.Models;

namespace Tarea3.Controllers
{
    public class MembresiaController : Controller
    {
        private readonly AppDBContext _context;

        public MembresiaController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Membresia
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Membresia.Include(m => m.Cliente).Include(m => m.Plan);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Membresia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresia
                .Include(m => m.Cliente)
                .Include(m => m.Plan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membresia == null)
            {
                return NotFound();
            }

            return View(membresia);
        }

        // GET: Membresia/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            ViewData["PlanId"] = new SelectList(_context.Plan, "Id", "Id");
            return View();
        }

        // POST: Membresia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,PlanId,FechaInicio,FechaExpiracion,Estado")] Membresia membresia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membresia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", membresia.ClienteId);
            ViewData["PlanId"] = new SelectList(_context.Plan, "Id", "Id", membresia.PlanId);
            return View(membresia);
        }

        // GET: Membresia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresia.FindAsync(id);
            if (membresia == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", membresia.ClienteId);
            ViewData["PlanId"] = new SelectList(_context.Plan, "Id", "Id", membresia.PlanId);
            return View(membresia);
        }

        // POST: Membresia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,PlanId,FechaInicio,FechaExpiracion,Estado")] Membresia membresia)
        {
            if (id != membresia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membresia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembresiaExists(membresia.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", membresia.ClienteId);
            ViewData["PlanId"] = new SelectList(_context.Plan, "Id", "Id", membresia.PlanId);
            return View(membresia);
        }

        // GET: Membresia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresia
                .Include(m => m.Cliente)
                .Include(m => m.Plan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membresia == null)
            {
                return NotFound();
            }

            return View(membresia);
        }

        // POST: Membresia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membresia = await _context.Membresia.FindAsync(id);
            if (membresia != null)
            {
                _context.Membresia.Remove(membresia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembresiaExists(int id)
        {
            return _context.Membresia.Any(e => e.Id == id);
        }
    }
}
