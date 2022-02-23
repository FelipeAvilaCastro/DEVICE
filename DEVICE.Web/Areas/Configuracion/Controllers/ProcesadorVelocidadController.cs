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
    public class ProcesadorVelocidadController : Controller
    {
        private readonly DeviceDBContext _context;

        public ProcesadorVelocidadController(DeviceDBContext context)
        {
            _context = context;
        }

        // GET: Configuracion/ProcesadorVelocidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcesadorVelocidad.ToListAsync());
        }

        // GET: Configuracion/ProcesadorVelocidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesadorVelocidad = await _context.ProcesadorVelocidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesadorVelocidad == null)
            {
                return NotFound();
            }

            return View(procesadorVelocidad);
        }

        // GET: Configuracion/ProcesadorVelocidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Configuracion/ProcesadorVelocidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] ProcesadorVelocidad procesadorVelocidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesadorVelocidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesadorVelocidad);
        }

        // GET: Configuracion/ProcesadorVelocidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesadorVelocidad = await _context.ProcesadorVelocidad.FindAsync(id);
            if (procesadorVelocidad == null)
            {
                return NotFound();
            }
            return View(procesadorVelocidad);
        }

        // POST: Configuracion/ProcesadorVelocidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] ProcesadorVelocidad procesadorVelocidad)
        {
            if (id != procesadorVelocidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesadorVelocidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesadorVelocidadExists(procesadorVelocidad.Id))
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
            return View(procesadorVelocidad);
        }

        // GET: Configuracion/ProcesadorVelocidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesadorVelocidad = await _context.ProcesadorVelocidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesadorVelocidad == null)
            {
                return NotFound();
            }

            return View(procesadorVelocidad);
        }

        // POST: Configuracion/ProcesadorVelocidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesadorVelocidad = await _context.ProcesadorVelocidad.FindAsync(id);
            _context.ProcesadorVelocidad.Remove(procesadorVelocidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesadorVelocidadExists(int id)
        {
            return _context.ProcesadorVelocidad.Any(e => e.Id == id);
        }
    }
}
