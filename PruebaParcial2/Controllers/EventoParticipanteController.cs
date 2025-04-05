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
    public class EventoParticipanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventoParticipanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventoParticipante
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventoParticipantes.Include(e => e.Evento).Include(e => e.Participante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventoParticipante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoParticipante = await _context.EventoParticipantes
                .Include(e => e.Evento)
                .Include(e => e.Participante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoParticipante == null)
            {
                return NotFound();
            }

            return View(eventoParticipante);
        }

        // GET: EventoParticipante/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre");
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "Id", "Nombre");
            return View();
        }

        // POST: EventoParticipante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventoId,FechaInscripcion,ParticipanteId")] EventoParticipante eventoParticipante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventoParticipante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre", eventoParticipante.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "Id", "Nombre", eventoParticipante.ParticipanteId);
            return View(eventoParticipante);
        }

        // GET: EventoParticipante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoParticipante = await _context.EventoParticipantes.FindAsync(id);
            if (eventoParticipante == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre", eventoParticipante.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "Id", "Nombre", eventoParticipante.ParticipanteId);
            return View(eventoParticipante);
        }

        // POST: EventoParticipante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventoId,FechaInscripcion,ParticipanteId")] EventoParticipante eventoParticipante)
        {
            if (id != eventoParticipante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventoParticipante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoParticipanteExists(eventoParticipante.Id))
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
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre", eventoParticipante.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "Id", "Nombre", eventoParticipante.ParticipanteId);
            return View(eventoParticipante);
        }

        [Authorize(Roles = "Admin")]
        // GET: EventoParticipante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoParticipante = await _context.EventoParticipantes
                .Include(e => e.Evento)
                .Include(e => e.Participante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoParticipante == null)
            {
                return NotFound();
            }

            return View(eventoParticipante);
        }

        // POST: EventoParticipante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventoParticipante = await _context.EventoParticipantes.FindAsync(id);
            if (eventoParticipante != null)
            {
                _context.EventoParticipantes.Remove(eventoParticipante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoParticipanteExists(int id)
        {
            return _context.EventoParticipantes.Any(e => e.Id == id);
        }
    }
}
