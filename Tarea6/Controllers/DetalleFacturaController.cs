using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea5.Data;
using Tarea5.Models;

namespace Tarea5.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleFacturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalleFactura
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetalleFactura.Include(d => d.FacturaModel).Include(d => d.ProductoModel).Include(d => d.StockModel);
            return View(await applicationDbContext.ToListAsync());
        }

        public List<ClientesModel> ListaClientes()
        {
            return _context.Clientes.ToList();
        }

        // GET: DetalleFactura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFacturaModel = await _context.DetalleFactura
                .Include(d => d.FacturaModel)
                .Include(d => d.ProductoModel)
                .Include(d => d.StockModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFacturaModel == null)
            {
                return NotFound();
            }

            return View(detalleFacturaModel);
        }

        // GET: DetalleFactura/Create
        public IActionResult Create()
        {
            ViewData["FacturaModelId"] = new SelectList(_context.Facturas, "Id", "Id");
            ViewData["ProductoModelId"] = new SelectList(_context.Productos, "Id", "NombreProducto");
            ViewData["StockModelId"] = new SelectList(_context.Stocks, "Id", "Id");
            return View();
        }

        // POST: DetalleFactura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,valor,ProductoModelId,FacturaModelId,StockModelId")] DetalleFacturaModel detalleFacturaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFacturaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaModelId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFacturaModel.FacturaModelId);
            ViewData["ProductoModelId"] = new SelectList(_context.Productos, "Id", "NombreProducto", detalleFacturaModel.ProductoModelId);
            ViewData["StockModelId"] = new SelectList(_context.Stocks, "Id", "Id", detalleFacturaModel.StockModelId);
            return View(detalleFacturaModel);
        }

        // GET: DetalleFactura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFacturaModel = await _context.DetalleFactura.FindAsync(id);
            if (detalleFacturaModel == null)
            {
                return NotFound();
            }
            ViewData["FacturaModelId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFacturaModel.FacturaModelId);
            ViewData["ProductoModelId"] = new SelectList(_context.Productos, "Id", "NombreProducto", detalleFacturaModel.ProductoModelId);
            ViewData["StockModelId"] = new SelectList(_context.Stocks, "Id", "Id", detalleFacturaModel.StockModelId);
            return View(detalleFacturaModel);
        }

        // POST: DetalleFactura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,valor,ProductoModelId,FacturaModelId,StockModelId")] DetalleFacturaModel detalleFacturaModel)
        {
            if (id != detalleFacturaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFacturaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaModelExists(detalleFacturaModel.Id))
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
            ViewData["FacturaModelId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFacturaModel.FacturaModelId);
            ViewData["ProductoModelId"] = new SelectList(_context.Productos, "Id", "NombreProducto", detalleFacturaModel.ProductoModelId);
            ViewData["StockModelId"] = new SelectList(_context.Stocks, "Id", "Id", detalleFacturaModel.StockModelId);
            return View(detalleFacturaModel);
        }

        // GET: DetalleFactura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFacturaModel = await _context.DetalleFactura
                .Include(d => d.FacturaModel)
                .Include(d => d.ProductoModel)
                .Include(d => d.StockModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFacturaModel == null)
            {
                return NotFound();
            }

            return View(detalleFacturaModel);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFacturaModel = await _context.DetalleFactura.FindAsync(id);
            if (detalleFacturaModel != null)
            {
                _context.DetalleFactura.Remove(detalleFacturaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaModelExists(int id)
        {
            return _context.DetalleFactura.Any(e => e.Id == id);
        }
    }
}
