using DEVICE.Web.Repos;
using DEVICE.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Licencia.Controllers
{

    [Area(nameof(Licencia))]
    public class RegistroController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var listado = new RegistroLicenciaViewModel();
            listado.ListadoLicencia = await LicenciaRepo.ObtenerLicencia();
            listado.ListadoSoftware = await SoftwareRepo.ObtenerSoftware();
            listado.ListadoSoftwareModulo = await SoftwareModuloRepo.ObtenerModulo();
            listado.ListadoSoftwareVersion = await SoftwareVersionRepo.ObtenerVersion();
            return View(listado);
        }

        public async Task<IActionResult> Listado()
        {

            var listado = new RegistroLicenciaViewModel();
            listado.ListadoLicencia = await LicenciaRepo.ObtenerLicencia();
            listado.ListadoSoftware = await SoftwareRepo.ObtenerSoftware();
            listado.ListadoSoftwareModulo = await SoftwareModuloRepo.ObtenerModulo();
            listado.ListadoSoftwareVersion = await SoftwareVersionRepo.ObtenerVersion();

            return PartialView(listado);

        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Models.Licencia licencia)
        {
            bool exito = true;
            if (licencia.Id <= 0)
                exito = await LicenciaRepo.RegistrarLicencia(licencia);
            else
                exito = await LicenciaRepo.ActualizarLicencia(licencia);
           
            if (exito)
                return Json(exito);
            return RedirectToAction(nameof(Index));
        }

    }
}
