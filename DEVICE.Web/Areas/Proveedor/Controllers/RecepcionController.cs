using DEVICE.Web.Models;
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
    public class RecepcionController : Controller
    {

        private readonly IHostingEnvironment _env;

        public RecepcionController(IHostingEnvironment env)
        {
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            var listado = new RegistroDocumentoViewModel();
            listado.ListadoProveedor = await ProveedorRepo.ObtenerProveedor();
            listado.ListadoProducto =await ProductoRepo.ObtenerProducto();
            listado.ListadoTipoProducto = await TipoProductoRepo.ObtenerTipoProducto();

            return View(listado);
        }


        [HttpPost]
        public async Task<IActionResult> GrabarEncabezado([FromBody] Documento documento)
        {
            bool exito = true;
            //string exito = String.Empty;
            //DateTime fechaRegistro = Convert.ToDateTime(Request.Form["vFechaRegistro"]).Date;

            if (documento.Id <= 0)
                exito = await DocumentoRepo.RegistrarDocumento(documento);
            else
                exito = await DocumentoRepo.ActualizarDocumento(documento);
            //if (exito)
            return Json(exito);
            //return RedirectToAction(nameof(Index));
        }





        [HttpPost]
        public async Task<IActionResult> JsonProducto(int idProducto)
        {
            JsonProductoViewModels data = new JsonProductoViewModels { Parte = "AAxxx",
                Precio = "5000", Producto="Computador" };
            return Json(data);
            //return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Listado()
        {
            var listado = new RegistroDocumentoViewModel();
            listado.ListadoDocumento = await DocumentoRepo.ObtenerDocumento();
            listado.ListadoProveedor = await ProveedorRepo.ObtenerProveedor();
            //listado.ListadoTipoProducto = await TipoProductoRepo.ObtenerTipoProducto();
            return PartialView(listado);
        }


    }
}
