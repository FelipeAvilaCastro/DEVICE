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

    public class AsignacionSucursalController : Controller
    {

        private readonly IHostingEnvironment _env;

        public AsignacionSucursalController(IHostingEnvironment env)
        {
            _env = env;
        }

        //Variable del entorno env - Inyeccion de dependencia del entorno env -
        //Inyectarlo en el controlador para refactorizar - Asignar AspNetCore.Hosting - por que necesitamos la ruta del proyecto


        public async Task<IActionResult> Index()
            
        {
            var equiposucursalVM = new EquipoSucursalViewModel(); 
            equiposucursalVM.ListadoSucursal = await SucursalRepo.ObtenerSucursal();
            equiposucursalVM.ListadoProducto = await ProductoRepo.ObtenerProductoDisponibleSucursal();

            return View(equiposucursalVM);
        }


        public async Task<IActionResult> Listado ()
        {

            var listado = await SucursalProductoRepo.ObtenerSucursalProducto();
            return PartialView(listado);

        }

        [HttpPost]
        public async Task<IActionResult> Grabar()


        {
            bool exito = true;
            try
            {
                bool tieneFoto = Convert.ToBoolean(Request.Form.Where(x => x.Key == "vTieneFoto").FirstOrDefault().Value);

                int idSucursalProducto = Convert.ToInt32(Request.Form.Where(x => x.Key == "vIDSucursalProducto").FirstOrDefault().Value);
                int idEquipo = Convert.ToInt32(Request.Form.Where(x => x.Key == "vEquipo").FirstOrDefault().Value);
                int idSucursal = Convert.ToInt32(Request.Form.Where(x => x.Key == "vSucursal").FirstOrDefault().Value);

                DateTime fechaEntrega = Convert.ToDateTime(Request.Form["vFechaEntrega"]).Date;
                string comentario = Request.Form.Where(x => x.Key == "vComentario").FirstOrDefault().Value;


                var fileFoto = (dynamic)null;   //Request.Form.Files.Count == 0 ? null : Request.Form.Files[1];
                if (tieneFoto)
                {
                    fileFoto = Request.Form.Files[0];
                }

                string fileNameFoto = fileFoto == null ? fileFoto : DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fileFoto.FileName).ToLowerInvariant();


                var asignacion = new SucursalProducto()
                {
                    SucursalId = idSucursal,
                    ProductoId = idEquipo,
                    FechaEntrega = fechaEntrega,
                    Estado = true,
                    Comentario = comentario,
 
                };




                if (idSucursalProducto == -1)
                    exito = await SucursalProductoRepo.RegistrarSucursalProducto(asignacion);
                else
                {
                    asignacion.Id = idSucursalProducto;
                    exito = await SucursalProductoRepo.ActualizarSucursalProducto(asignacion);
                }

                if (!exito)
                    return Json(false);
                

                var evidenciaFoto = new SucursalProductoEvidencia();

                try
                {
                    if (fileFoto != null)
                    {
                        //evidenciaFoto.SucursalProductoId = asignacion.Id;
                        //evidenciaFoto.NombreArchivo = fileNameFoto;
                        //evidenciaFoto.FechaArchivo = DateTime.Now;
                        //evidenciaFoto.Tipo = "P";

                        var evidenciaUpdate = await SucursalProductoEvidenciaRepo.ObtenerEvidenciaPorTipo(idSucursalProducto, "P");
                        if (idSucursalProducto == -1 || evidenciaUpdate == null)
                        {
                            evidenciaFoto.SucursalProductoId = asignacion.Id;
                            evidenciaFoto.NombreArchivo = fileNameFoto;
                            evidenciaFoto.FechaArchivo = DateTime.Now;
                            evidenciaFoto.Tipo = "P";
                            exito = await SucursalProductoEvidenciaRepo.RegistrarEvidencia(evidenciaFoto);
                        }
                        else
                        {

                            evidenciaUpdate.SucursalProductoId = asignacion.Id;
                            evidenciaUpdate.NombreArchivo = fileNameFoto;
                            evidenciaUpdate.FechaArchivo = DateTime.Now;
                            evidenciaUpdate.Tipo = "P";
                            exito = await SucursalProductoEvidenciaRepo.ActualizarEvidencia(evidenciaUpdate);
                        }

                        var filePath = Path.Combine(_env.ContentRootPath + "/Documents/AsignacionSucursal/",
                            fileNameFoto);

                        using var stream = System.IO.File.Create(filePath);
                        await fileFoto.CopyToAsync(stream);

                    }


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
        public async Task<IActionResult> ObtenerProductoPorSucursalProductoID(int id)
        {
            var producto = await SucursalRepo.ObtenerProductoPorSucursalProductoID(id);
            return Json(producto);
        }


        public async Task<IActionResult> Obtener(int id)
        {
            var producto = await SucursalProductoRepo.ObtenerSucursalProductoPorID(id);
            return Json(producto);
        }


        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id, bool estado)
        {

            var exito = await SucursalProductoRepo.CambiarEstado(id, !estado);
            return Json(exito);

        }

        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this._env.ContentRootPath, "Documents/AsignacionSucursal/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

    }
}
