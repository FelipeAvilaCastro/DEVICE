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
    public class ProcesadorGeneracionController : Controller
    {
        private readonly DeviceDBContext _context;

        public ProcesadorGeneracionController(DeviceDBContext context)
        {
            _context = context;
        }

        // GET: Configuracion/ProcesadorGeneracion
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcesadorGeneracion.ToListAsync());
        }

        // GET: Configuracion/ProcesadorGeneracion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesadorGeneracion = await _context.ProcesadorGeneracion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesadorGeneracion == null)
            {
                return NotFound();
            }

            return View(procesadorGeneracion);
        }

        // GET: Configuracion/ProcesadorGeneracion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Configuracion/ProcesadorGeneracion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] ProcesadorGeneracion procesadorGeneracion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesadorGeneracion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesadorGeneracion);
        }

        // GET: Configuracion/ProcesadorGeneracion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesadorGeneracion = await _context.ProcesadorGeneracion.FindAsync(id);
            if (procesadorGeneracion == null)
            {
                return NotFound();
            }
            return View(procesadorGeneracion);
        }

        // POST: Configuracion/ProcesadorGeneracion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] ProcesadorGeneracion procesadorGeneracion)
        {
            if (id != procesadorGeneracion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesadorGeneracion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesadorGeneracionExists(procesadorGeneracion.Id))
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
            return View(procesadorGeneracion);
        }

        // GET: Configuracion/ProcesadorGeneracion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesadorGeneracion = await _context.ProcesadorGeneracion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesadorGeneracion == null)
            {
                return NotFound();
            }

            return View(procesadorGeneracion);
        }

        // POST: Configuracion/ProcesadorGeneracion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesadorGeneracion = await _context.ProcesadorGeneracion.FindAsync(id);
            _context.ProcesadorGeneracion.Remove(procesadorGeneracion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesadorGeneracionExists(int id)
        {
            return _context.ProcesadorGeneracion.Any(e => e.Id == id);
        }
    }
}
