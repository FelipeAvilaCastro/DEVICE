using DEVICE.Web.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Persona.Controllers
{
    [Area(nameof(Persona))]
    public class UbicacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Listado()
        {
            var listado = await UbicacionRepo.ObtenerUbicacion();
            return PartialView(listado);
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Models.Ubicacion ubicacion)
        {
            bool exito = true;
            if (ubicacion.ID <= 0)
                exito = await UbicacionRepo.RegistrarUbicacion(ubicacion);
            else
                exito = await UbicacionRepo.ActualizarUbicacion(ubicacion);

            if (exito)
                return Json(exito);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Obtener(int id)
        {
            var ubicacion = await UbicacionRepo.ObtenerUbicacionPorID(id);
            return Json(ubicacion);
        }


        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await UbicacionRepo.EliminarUbicacion(id);
            return Json(exito);
        }


    }
}
