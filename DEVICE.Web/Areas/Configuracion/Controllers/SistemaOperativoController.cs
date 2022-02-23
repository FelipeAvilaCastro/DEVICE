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
    public class SistemaOperativoController : Controller
    {
        private readonly DeviceDBContext _context;

        public SistemaOperativoController(DeviceDBContext context)
        {
            _context = context;
        }

        // GET: Configuracion/SistemaOperativo
        public async Task<IActionResult> Index()
        {
            return View(await _context.SistemaOperativo.ToListAsync());
        }

        // GET: Configuracion/SistemaOperativo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }

            return View(sistemaOperativo);
        }

        // GET: Configuracion/SistemaOperativo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Configuracion/SistemaOperativo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] SistemaOperativo sistemaOperativo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistemaOperativo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sistemaOperativo);
        }

        // GET: Configuracion/SistemaOperativo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativo.FindAsync(id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }
            return View(sistemaOperativo);
        }

        // POST: Configuracion/SistemaOperativo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] SistemaOperativo sistemaOperativo)
        {
            if (id != sistemaOperativo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistemaOperativo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemaOperativoExists(sistemaOperativo.Id))
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
            return View(sistemaOperativo);
        }

        // GET: Configuracion/SistemaOperativo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }

            return View(sistemaOperativo);
        }

        // POST: Configuracion/SistemaOperativo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sistemaOperativo = await _context.SistemaOperativo.FindAsync(id);
            _context.SistemaOperativo.Remove(sistemaOperativo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SistemaOperativoExists(int id)
        {
            return _context.SistemaOperativo.Any(e => e.Id == id);
        }
    }
}
