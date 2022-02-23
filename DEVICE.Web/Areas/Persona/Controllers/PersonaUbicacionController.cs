using DEVICE.Web.Repos;
using DEVICE.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Persona.Controllers
{

    [Area(nameof(Persona))]
    public class PersonaUbicacionController : Controller
    {
        private readonly IHostingEnvironment _env;

        public PersonaUbicacionController(IHostingEnvironment env)
        {
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            var personaubicacionVM = new PersonaUbicacionViewModel() 
            {
                ListadoPersona = await PersonaRepo.ObtenerPersona(),
                ListadoUbicacion = await UbicacionRepo.ObtenerUbicacion(),
            };

            return View(personaubicacionVM);
        }

        public async Task<IActionResult> Listado()
        {

            var listado = new PersonaUbicacionViewModel();
            listado.ListadoPersonaUbicacion = await PersonaUbicacionRepo.ObtenerPersonaUbicacion();
            listado.ListadoPersona = await PersonaRepo.ObtenerPersona();
            listado.ListadoUbicacion = await UbicacionRepo.ObtenerUbicacion();
            return PartialView(listado);
        }


        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Models.PersonaUbicacion personaubicacion)

        {
            bool exito = true;
            if (personaubicacion.Id <= 0)
                exito = await PersonaUbicacionRepo.RegistrarPersonaUbicacion(personaubicacion);
            else
                exito = await PersonaUbicacionRepo.RegistrarPersonaUbicacion(personaubicacion);

            if (exito)
                return Json(exito);
            return RedirectToAction(nameof(Index));
        }



    }
}
