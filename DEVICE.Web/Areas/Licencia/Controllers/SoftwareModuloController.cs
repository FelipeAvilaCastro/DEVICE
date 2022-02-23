using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DEVICE.Web.Models;

namespace DEVICE.Web.Areas.Licencia.Controllers
{
    [Area("Licencia")]
    public class SoftwareModuloController : Controller
    {
        private readonly DeviceDBContext _context;

        public SoftwareModuloController(DeviceDBContext context)
        {
            _context = context;
        }

        // GET: Licencia/SoftwareModulo
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoftwareModulo.ToListAsync());
        }

        // GET: Licencia/SoftwareModulo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareModulo = await _context.SoftwareModulo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (softwareModulo == null)
            {
                return NotFound();
            }

            return View(softwareModulo);
        }

        // GET: Licencia/SoftwareModulo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Licencia/SoftwareModulo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] SoftwareModulo softwareModulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(softwareModulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(softwareModulo);
        }

        // GET: Licencia/SoftwareModulo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareModulo = await _context.SoftwareModulo.FindAsync(id);
            if (softwareModulo == null)
            {
                return NotFound();
            }
            return View(softwareModulo);
        }

        // POST: Licencia/SoftwareModulo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] SoftwareModulo softwareModulo)
        {
            if (id != softwareModulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(softwareModulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareModuloExists(softwareModulo.Id))
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
            return View(softwareModulo);
        }

        // GET: Licencia/SoftwareModulo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareModulo = await _context.SoftwareModulo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (softwareModulo == null)
            {
                return NotFound();
            }

            return View(softwareModulo);
        }

        // POST: Licencia/SoftwareModulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var softwareModulo = await _context.SoftwareModulo.FindAsync(id);
            _context.SoftwareModulo.Remove(softwareModulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareModuloExists(int id)
        {
            return _context.SoftwareModulo.Any(e => e.Id == id);
        }
    }
}
