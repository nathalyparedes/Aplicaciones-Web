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
    public class EventoOrganizadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventoOrganizadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventoOrganizador
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventoOrganizadores.Include(e => e.Evento).Include(e => e.Organizador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventoOrganizador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoOrganizador = await _context.EventoOrganizadores
                .Include(e => e.Evento)
                .Include(e => e.Organizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoOrganizador == null)
            {
                return NotFound();
            }

            return View(eventoOrganizador);
        }

        // GET: EventoOrganizador/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre");
            ViewData["OrganizadorId"] = new SelectList(_context.Organizadores, "Id", "Nombre");
            return View();
        }

        // POST: EventoOrganizador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventoId,OrganizadorId")] EventoOrganizador eventoOrganizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventoOrganizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre", eventoOrganizador.EventoId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizadores, "Id", "Nombre", eventoOrganizador.OrganizadorId);
            return View(eventoOrganizador);
        }

        // GET: EventoOrganizador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoOrganizador = await _context.EventoOrganizadores.FindAsync(id);
            if (eventoOrganizador == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre", eventoOrganizador.EventoId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizadores, "Id", "Nombre", eventoOrganizador.OrganizadorId);
            return View(eventoOrganizador);
        }

        // POST: EventoOrganizador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventoId,OrganizadorId")] EventoOrganizador eventoOrganizador)
        {
            if (id != eventoOrganizador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventoOrganizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoOrganizadorExists(eventoOrganizador.Id))
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
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nombre", eventoOrganizador.EventoId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizadores, "Id", "Nombre", eventoOrganizador.OrganizadorId);
            return View(eventoOrganizador);
        }

        [Authorize(Roles = "Admin")]
        // GET: EventoOrganizador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoOrganizador = await _context.EventoOrganizadores
                .Include(e => e.Evento)
                .Include(e => e.Organizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoOrganizador == null)
            {
                return NotFound();
            }

            return View(eventoOrganizador);
        }

        // POST: EventoOrganizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventoOrganizador = await _context.EventoOrganizadores.FindAsync(id);
            if (eventoOrganizador != null)
            {
                _context.EventoOrganizadores.Remove(eventoOrganizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoOrganizadorExists(int id)
        {
            return _context.EventoOrganizadores.Any(e => e.Id == id);
        }
    }
}
