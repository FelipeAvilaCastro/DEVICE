using DEVICE.Web.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Persona.Controllers
{
    [Area(nameof(Persona))]
    public class RegistroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var listado = await PersonaRepo.ObtenerPersona();
            return PartialView(listado);
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Models.Persona persona)
        {
            bool exito = true;
            if (persona.Id <= 0)
                exito = await PersonaRepo.RegistrarPersona(persona);
            else
                exito = await PersonaRepo.ActualizarPersona(persona);

            if (exito)
                return Json(exito);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await PersonaRepo.EliminarPersona(id);
            return Json(exito);
        }

    }
}
