using DEVICE.Web.Models;
using DEVICE.Web.Repos;
using DEVICE.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Equipo.Controllers
{
    [Area(nameof(Equipo))]
    public class RegistroController : Controller
    {

        //public async Task<IActionResult> Principal()
        //{
        //    return View();
        //}

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var listado = new RegistroEquipoViewModel();
            listado.ListadoTipoProducto = await TipoProductoRepo.ObtenerTipoProducto();
            listado.ListadoSistemaOperativo = await SistemaOperativoRepo.ObtenerSistemaOperativo();
            listado.ListadoFabricante = await FabricanteRepo.ObtenerFabricante();
            listado.ListadoProcesador = await ProcesadorRepo.ObtenerProcesador();
            listado.ListadoProcesadorGeneracion = await ProcesadorGeneracionRepo.ObtenerProcesadorGeneracion();
            listado.ListadoProcesadorVelocidad = await ProcesadorVelocidadRepo.ObtenerProcesadorVelocidad();
            listado.ListadoTipoDD = await TipoDDRepo.ObtenerTipoDD();

            return View(listado);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Producto producto)
        {
            string exito = String.Empty;
            //bool exito = true;
            if (producto.Id <= 0)
                exito = await ProductoRepo.RegistrarProducto(producto);
            else
                exito = await ProductoRepo.ActualizarProducto(producto);
                return Json(exito);

        }

        public async Task<IActionResult> Listado()
        {
            var listado = new EquipoFabricanteViewModel();
            listado.ListadoProducto = await ProductoRepo.ObtenerProducto();
            listado.ListadoTipoProducto = await TipoProductoRepo.ObtenerTipoProducto();
            listado.ListadoFabricante = await FabricanteRepo.ObtenerFabricante();
            listado.ListadoProcesador = await ProcesadorRepo.ObtenerProcesador();
            return PartialView(listado);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await ProductoRepo.EliminarProducto(id);
            return Json(exito);
        }

        public async Task<IActionResult> Obtener(int id)
        {
            var producto = await ProductoRepo.ObtenerProductoPorID(id);
            return Json(producto);
        }


    }
}