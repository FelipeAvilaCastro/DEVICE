using DEVICE.Web.Models;
using DEVICE.Web.Repos;
using DEVICE.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Equipo.Controllers
{

    [Area(nameof(Equipo))]
    public class AsignacionLicenciaController : Controller
    {

        private readonly IHostingEnvironment _env;

        public AsignacionLicenciaController(IHostingEnvironment env)
        {
            _env = env;
        }

        //Variable del entorno env - Inyeccion de dependencia del entorno env -
        //Inyectarlo en el controlador para refactorizar - Asignar AspNetCore.Hosting - por que necesitamos la ruta del proyecto


        public async Task<IActionResult> Index()
        {

            var equipolicenciaVM = new EquipoLicenciaViewModel();
            
            equipolicenciaVM.ListadoLicencia = await LicenciaRepo.ObtenerLicencia();
            equipolicenciaVM.ListadoProducto = await ProductoRepo.ObtenerLicenciaDisponible();

            return View(equipolicenciaVM);
        }

        public async Task<IActionResult> Listado()
        {
            var listado = await ProductoLicenciaRepo.ObtenerProductoLicencia();
            return PartialView(listado);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar()


        {
            bool exito = true;
            try
            {

                int idProductoLicencia = Convert.ToInt32(Request.Form.Where(x => x.Key == "vIDProductoLicencia").FirstOrDefault().Value);

                int idEquipo = Convert.ToInt32(Request.Form.Where(x => x.Key == "vEquipo").FirstOrDefault().Value);
                int idLicencia = Convert.ToInt32(Request.Form.Where(x => x.Key == "vLicencia").FirstOrDefault().Value);
                DateTime fechaInstalacion = Convert.ToDateTime(Request.Form["vFechaInstalacion"]).Date;
                bool tieneFoto = Convert.ToBoolean(Request.Form.Where(x => x.Key == "vTieneFoto").FirstOrDefault().Value);


                var fileFoto = (dynamic)null;   //Request.Form.Files.Count == 0 ? null : Request.Form.Files[1];
                if (tieneFoto)
                {
                    fileFoto = Request.Form.Files[0];
                }

                string fileNameFoto = fileFoto == null ? fileFoto : DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fileFoto.FileName).ToLowerInvariant();




                var asignacion = new ProductoLicencia()
                {
                    ProductoId = idEquipo,
                    LicenciaId = idLicencia,
                    FechaConfiguracion = fechaInstalacion,
                    Estado = true,
                };

                if (idProductoLicencia == -1)
                    exito = await ProductoLicenciaRepo.RegistrarProductoLicencia(asignacion);
                else
                {
                    asignacion.Id = idProductoLicencia;
                    exito = await ProductoLicenciaRepo.ActualizarProductoLicencia(asignacion);
                }

                if (!exito)
                    return Json(false);




                var evidenciaFoto = new ProductoLicenciaEvidencia();

                try
                {
                    if (fileFoto != null)
                    {
                        evidenciaFoto.ProductoLicenciaId = asignacion.Id;
                        evidenciaFoto.NombreArchivo = fileNameFoto;
                        evidenciaFoto.FechaArchivo = DateTime.Now;


                        var filePath = Path.Combine(_env.ContentRootPath + "/Documents/AsignacionLicencia/", fileNameFoto);

                        using var stream = System.IO.File.Create(filePath);
                        await fileFoto.CopyToAsync(stream);

                    }

                    exito = await ProductoLicenciaEvidenciaRepo.RegistrarEvidencia(evidenciaFoto);

                }
                catch (Exception message)
                {

                    exito = false;
                }

            }

            catch (Exception)
            {
                exito = false;
            }

            return Json(exito);
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerProductoPorProductoLicenciaID(int id)
        {
            var producto = await ProductoRepo.ObtenerProductoPorProductoLicenciaID(id);
            return Json(producto);
        }

        public async Task<IActionResult> Obtener(int id)
        {
            var producto = await ProductoLicenciaRepo.ObtenerProductoLicenciaPorID(id);
            return Json(producto);
        }

    }

}
