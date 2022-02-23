using DEVICE.Web.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Configuracion.Controllers
{

    [Area(nameof(Configuracion))]
    public class ParteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var listado = await ParteRepo.ObtenerParte();
            return PartialView(listado);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Models.Parte parte)
        {
            bool exito = true;
            if (parte.Id <= 0)
                exito = await ParteRepo.RegistrarParte(parte);
            //else
            //    exito = await ParteRepo.ActualizarDepartamento(departamento);

            if (exito)
                return Json(exito);
            return RedirectToAction(nameof(Index));
        }



    }
}
