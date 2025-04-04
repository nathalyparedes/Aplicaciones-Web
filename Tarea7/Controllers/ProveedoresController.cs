using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea7.Data;
using Tarea7.Models;

namespace Tarea5.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proveedores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proveedores.ToListAsync());
        }

        // GET: Proveedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedoresModel = await _context.Proveedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proveedoresModel == null)
            {
                return NotFound();
            }

            return View(proveedoresModel);
        }

        // GET: Proveedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreProveedor,Direccion,Telefono,Correo")] ProveedoresModel proveedoresModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedoresModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedoresModel);
        }

        // GET: Proveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedoresModel = await _context.Proveedores.FindAsync(id);
            if (proveedoresModel == null)
            {
                return NotFound();
            }
            return View(proveedoresModel);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreProveedor,Direccion,Telefono,Correo")] ProveedoresModel proveedoresModel)
        {
            if (id != proveedoresModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedoresModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedoresModelExists(proveedoresModel.Id))
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
            return View(proveedoresModel);
        }

        // GET: Proveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedoresModel = await _context.Proveedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proveedoresModel == null)
            {
                return NotFound();
            }

            return View(proveedoresModel);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedoresModel = await _context.Proveedores.FindAsync(id);
            if (proveedoresModel != null)
            {
                _context.Proveedores.Remove(proveedoresModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedoresModelExists(int id)
        {
            return _context.Proveedores.Any(e => e.Id == id);
        }
    }
}
