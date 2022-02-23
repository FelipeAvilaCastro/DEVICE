using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DEVICE.Web.Models;

namespace DEVICE.Web.Areas.Configuracion.Controllers
{
    [Area("Configuracion")]
    public class ProcesadorController : Controller
    {
        private readonly DeviceDBContext _context;

        public ProcesadorController(DeviceDBContext context)
        {
            _context = context;
        }

        // GET: Configuracion/Procesador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procesador.ToListAsync());
        }

        // GET: Configuracion/Procesador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesador == null)
            {
                return NotFound();
            }

            return View(procesador);
        }

        // GET: Configuracion/Procesador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Configuracion/Procesador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] Procesador procesador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesador);
        }

        // GET: Configuracion/Procesador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador.FindAsync(id);
            if (procesador == null)
            {
                return NotFound();
            }
            return View(procesador);
        }

        // POST: Configuracion/Procesador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Procesador procesador)
        {
            if (id != procesador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesadorExists(procesador.Id))
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
            return View(procesador);
        }

        // GET: Configuracion/Procesador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesador == null)
            {
                return NotFound();
            }

            return View(procesador);
        }

        // POST: Configuracion/Procesador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesador = await _context.Procesador.FindAsync(id);
            _context.Procesador.Remove(procesador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesadorExists(int id)
        {
            return _context.Procesador.Any(e => e.Id == id);
        }
    }
}
