using DEVICE.Web.Repos;
using DEVICE.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        
        public async Task<IActionResult> Index()
        {
            var listado = new RegistroUsuarioViewModel();
            listado.ListadoPersona = await PersonaRepo.ObtenerPersona();
            listado.ListadoDepartamento = await DepartamentoRepo.ObtenerDepartamento();
            listado.ListadoSucursal = await SucursalRepo.ObtenerSucursal();
            return View(listado);

            //var departamentoVM = new RegistroPersonaViewModel()
            //{
            //    ListadoDepartamento = await DepartamentoRepo.ObtenerDepartamento()
            //};
            //return View(departamentoVM);

        }

        public async Task<IActionResult> Listado()
        {
            //var listado = await PersonaRepo.ObtenerPersona();
            //return PartialView(listado);
            var listado = new RegistroUsuarioViewModel();
            listado.ListadoPersona = await PersonaRepo.ObtenerPersona();
            listado.ListadoDepartamento = await DepartamentoRepo.ObtenerDepartamento();
            listado.ListadoSucursal = await SucursalRepo.ObtenerSucursal();
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


        public async Task<IActionResult> Obtener(int id)
        {
            var producto = await PersonaRepo.ObtenerPersonaPorID(id);
            return Json(producto);
        }

    }
}
