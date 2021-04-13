using DEVICE.Web.Models;
using DEVICE.Web.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Controllers
{
    public class SeguridadController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string codigo, string contrasena)
        {
            Persona persona = await PersonaRepo.GetPersonaPorCredenciales(codigo, contrasena);
            if (persona != null)
            {
                return RedirectToAction("Dashboard", "Main", new { area = "Administrativo" });
            }

            return RedirectToAction(nameof(Login));
        }

    }
}
