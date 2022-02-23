using DEVICE.Web.Repos;
using DEVICE.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Proveedor.Controllers
{

    [Area(nameof(Proveedor))]
    public class RegistroController : Controller
    {
        private readonly IHostingEnvironment _env;

        public RegistroController(IHostingEnvironment env)
        {
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            var listado = new RegistroProveedorViewModel();
            listado.ListadoProveedor = await ProveedorRepo.ObtenerProveedor();
            listado.ListadoPais = await PaisRepo.ObtenerPais();
            listado.ListadoEstado = await EstadoRepo.ObtenerEstado();
            listado.ListadoCiudad = await CiudadRepo.ObtenerCiudad();
            return View(listado);
            
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Models.Proveedor proveedor)
        {
            //bool exito = true;
            string exito = String.Empty;
            //DateTime fechaRegistro = Convert.ToDateTime(Request.Form["vFechaRegistro"]).Date;

            if (proveedor.Id <= 0)
                exito = await ProveedorRepo.RegistrarProveedor(proveedor);
            else
                exito = await ProveedorRepo.ActualizarProveedor(proveedor);
            //if (exito)
                return Json(exito);
            //return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Listado()
        {
            var listado = new RegistroProveedorViewModel();
            listado.ListadoProveedor = await ProveedorRepo.ObtenerProveedor();
            listado.ListadoPais = await PaisRepo.ObtenerPais();
            listado.ListadoEstado = await EstadoRepo.ObtenerEstado();
            listado.ListadoCiudad = await CiudadRepo.ObtenerCiudad();
            return PartialView(listado);
        }


        public async Task<IActionResult> ObtenerProveedor(int id)
        {
            var proveedor = await ProveedorRepo.ObtenerProveedorPorID(id);
            return Json(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await ProveedorRepo.EliminarProveedor(id);
            return Json(exito);
        }



    }
}
