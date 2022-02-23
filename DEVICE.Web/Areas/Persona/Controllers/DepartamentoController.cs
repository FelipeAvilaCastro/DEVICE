using DEVICE.Web.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Persona.Controllers
{
    [Area(nameof(Persona))]

    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var listado = await DepartamentoRepo.ObtenerDepartamento();
            return PartialView(listado);
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Models.Departamento departamento)
        {
            bool exito = true;
            if (departamento.Id <= 0)
                exito = await DepartamentoRepo.RegistrarDepartamento(departamento);
            else
                exito = await DepartamentoRepo.ActualizarDepartamento(departamento);

            if (exito)
                return Json(exito);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Obtener(int id)
        {
            var producto = await DepartamentoRepo.ObtenerDepartamentoPorID(id);
            return Json(producto);
        }


        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await DepartamentoRepo.EliminarDepartamento(id);
            return Json(exito);
        }


    }
}
