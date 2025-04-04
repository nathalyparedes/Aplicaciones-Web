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

    public class OrganizadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organizador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organizadores.ToListAsync());
        }

        // GET: Organizador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizador == null)
            {
                return NotFound();
            }

            return View(organizador);
        }

        // GET: Organizador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,TipoOrganizacion")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizador);
        }

        // GET: Organizador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizadores.FindAsync(id);
            if (organizador == null)
            {
                return NotFound();
            }
            return View(organizador);
        }

        // POST: Organizador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,TipoOrganizacion")] Organizador organizador)
        {
            if (id != organizador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizadorExists(organizador.Id))
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
            return View(organizador);
        }

        [Authorize(Roles = "Admin")]

        // GET: Organizador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizador == null)
            {
                return NotFound();
            }

            return View(organizador);
        }

        // POST: Organizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizador = await _context.Organizadores.FindAsync(id);
            if (organizador != null)
            {
                _context.Organizadores.Remove(organizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizadorExists(int id)
        {
            return _context.Organizadores.Any(e => e.Id == id);
        }
    }
}
