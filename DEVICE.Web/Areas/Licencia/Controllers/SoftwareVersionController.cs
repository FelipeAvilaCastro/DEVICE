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
    public class SoftwareVersionController : Controller
    {
        private readonly DeviceDBContext _context;

        public SoftwareVersionController(DeviceDBContext context)
        {
            _context = context;
        }

        // GET: Licencia/SoftwareVersion
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoftwareVersion.ToListAsync());
        }

        // GET: Licencia/SoftwareVersion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareVersion = await _context.SoftwareVersion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (softwareVersion == null)
            {
                return NotFound();
            }

            return View(softwareVersion);
        }

        // GET: Licencia/SoftwareVersion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Licencia/SoftwareVersion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] SoftwareVersion softwareVersion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(softwareVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(softwareVersion);
        }

        // GET: Licencia/SoftwareVersion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareVersion = await _context.SoftwareVersion.FindAsync(id);
            if (softwareVersion == null)
            {
                return NotFound();
            }
            return View(softwareVersion);
        }

        // POST: Licencia/SoftwareVersion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] SoftwareVersion softwareVersion)
        {
            if (id != softwareVersion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(softwareVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareVersionExists(softwareVersion.Id))
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
            return View(softwareVersion);
        }

        // GET: Licencia/SoftwareVersion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareVersion = await _context.SoftwareVersion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (softwareVersion == null)
            {
                return NotFound();
            }

            return View(softwareVersion);
        }

        // POST: Licencia/SoftwareVersion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var softwareVersion = await _context.SoftwareVersion.FindAsync(id);
            _context.SoftwareVersion.Remove(softwareVersion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareVersionExists(int id)
        {
            return _context.SoftwareVersion.Any(e => e.Id == id);
        }
    }
}
