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

    public class ParticipanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Participante
        public async Task<IActionResult> Index()
        {
            return View(await _context.Participantes.ToListAsync());
        }

        // GET: Participante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // GET: Participante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Participante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Contacto")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participante);
        }

        // GET: Participante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            return View(participante);
        }

        // POST: Participante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Contacto")] Participante participante)
        {
            if (id != participante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipanteExists(participante.Id))
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
            return View(participante);
        }

        [Authorize(Roles = "Admin")]

        // GET: Participante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // POST: Participante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante != null)
            {
                _context.Participantes.Remove(participante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipanteExists(int id)
        {
            return _context.Participantes.Any(e => e.Id == id);
        }
    }
}
