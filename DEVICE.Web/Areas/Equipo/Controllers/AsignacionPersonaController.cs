using DEVICE.Web.Models;
using DEVICE.Web.Repos;
using DEVICE.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Equipo.Controllers
{
    [Area(nameof(Equipo))]

    public class AsignacionPersonaController : Controller
    {
        private readonly IHostingEnvironment _env;

        public AsignacionPersonaController(IHostingEnvironment env)
        {
            _env = env;
        }


        public async Task<IActionResult> Reporte()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Usuario,Producto,FechaEntrega,FechaCambio,Estado");
            var listado = await PersonaProductoRepo.ObtenerPersonaProducto();
            foreach (var item in listado)
            {
                builder.AppendLine($"{item.Persona.Nombres + " " + item.Persona.Paterno}," +
                    $"{item.Producto.Modelo + " " + item.Producto.NumeroSerie},{item.FechaEntrega}," +
                    $"{item.FechaProximaCambio},{item.Estado}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "AsignacionPersona.csv");
        }



        public async Task<IActionResult> Index()
        {
            var equipopersonaVM = new EquipoPersonaViewModel()
            {
                ListadoPersona = await PersonaRepo.ObtenerPersona(),
                ListadoProducto = await ProductoRepo.ObtenerProductoDisponible(),
                ListadoClasificacion = await ClasificacionRepo.ObtenerClasificacion()

            };

            return View(equipopersonaVM);
        }

        public async Task<IActionResult> Listado()
        {
            var listado = await PersonaProductoRepo.ObtenerPersonaProducto(); 
            return PartialView(listado);
        }

        [HttpPost]
        public async Task<IActionResult> Grabar()
        {
            bool exito = true;
            try
            {
                bool tieneFirma = Convert.ToBoolean(Request.Form.Where(x => x.Key == "vTieneFirma").FirstOrDefault().Value);
                bool tieneFoto = Convert.ToBoolean(Request.Form.Where(x => x.Key == "vTieneFoto").FirstOrDefault().Value);

                int idPersonaProducto = Convert.ToInt32(Request.Form.Where(x => x.Key == "vIDPersonaProducto").FirstOrDefault().Value);
                int idEquipo = Convert.ToInt32(Request.Form.Where(x => x.Key == "vEquipo").FirstOrDefault().Value);
                int idPersona = Convert.ToInt32(Request.Form.Where(x => x.Key == "vPersona").FirstOrDefault().Value);

                DateTime fechaEntrega = Convert.ToDateTime(Request.Form["vFechaEntrega"]).Date;
                DateTime fechaProximoCambio = Convert.ToDateTime(Request.Form["vFechaProximoCambio"]).Date;
                string comentario = Request.Form.Where(x => x.Key == "vComentario").FirstOrDefault().Value;
                int idclasificacion = Convert.ToInt32(Request.Form.Where(x => x.Key == "vClasificacion").FirstOrDefault().Value);

                var fileFirma = (dynamic)null;  //Request.Form.Files.Count == 0 ? null : Request.Form.Files[0];
                var fileFoto = (dynamic)null;   //Request.Form.Files.Count == 0 ? null : Request.Form.Files[1];
                
                
                if (tieneFirma && tieneFoto)
                {
                    fileFirma = Request.Form.Files[0];
                    fileFoto = Request.Form.Files[1];
                }
                else if (tieneFirma && !tieneFoto)
                {
                    fileFirma = Request.Form.Files[0];
                }
                else if (!tieneFirma && tieneFoto)
                {
                    fileFoto = Request.Form.Files[0];
                }


                string fileNameFirma = fileFirma == null ? fileFirma : Guid.NewGuid().ToString() + Path.GetExtension(fileFirma.FileName).ToLowerInvariant();
                string fileNameFoto = fileFoto == null ? fileFoto : DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fileFoto.FileName).ToLowerInvariant();

                var asignacion = new PersonaProducto()
                {
                    PersonaId = idPersona,
                    ProductoId = idEquipo,
                    FechaProximaCambio = fechaProximoCambio,
                    FechaEntrega = fechaEntrega,
                    Comentario = comentario,
                    ClasificacionId = idclasificacion,
                    Estado = true
                };

                if (idPersonaProducto == -1)
                    exito = await PersonaProductoRepo.RegistrarPersonaProducto(asignacion);
                else
                {
                    asignacion.Id = idPersonaProducto;
                    exito = await PersonaProductoRepo.ActualizarPersonaProducto(asignacion);
                }

                if (!exito)
                    return Json(false);



                var evidenciaFirma = new PersonaProductoEvidencia();
                var evidenciaFoto = new PersonaProductoEvidencia();

                try
                {
                    if (fileFirma != null)
                    {
                        var evidenciaUpdate = await PersonaProductoEvidenciaRepo.ObtenerEvidenciaPorTipo(idPersonaProducto, "S");
                        if (idPersonaProducto == -1 || evidenciaUpdate==null)
                        {
                            evidenciaFirma.PersonaProductoId = asignacion.Id;
                            evidenciaFirma.NombreArchivo = fileNameFirma;
                            evidenciaFirma.FechaArchivo = DateTime.Now;
                            evidenciaFirma.Tipo = "S";
                            exito = await PersonaProductoEvidenciaRepo.RegistrarEvidencia(evidenciaFirma);
                        }
                        else {                            
                            evidenciaUpdate.PersonaProductoId = asignacion.Id;
                            evidenciaUpdate.NombreArchivo = fileNameFirma;
                            evidenciaUpdate.FechaArchivo = DateTime.Now;
                            evidenciaUpdate.Tipo = "S";
                            exito = await PersonaProductoEvidenciaRepo.ActualizarEvidencia(evidenciaUpdate);
                        }

                        var filePath = Path.Combine(_env.ContentRootPath + "/Documents/AsignacionPersona/",
                            fileNameFirma);

                        using var stream = System.IO.File.Create(filePath);
                        await fileFirma.CopyToAsync(stream);


                        //if (idPersonaProducto == -1)
                        //    exito = await PersonaProductoEvidenciaRepo.RegistrarEvidencia(evidenciaFirma);
                        //else
                        //    exito = await PersonaProductoEvidenciaRepo.ActualizarEvidencia(evidenciaFirma);

                    }

                }
                catch (Exception)
                {

                    exito = false;
                }



                try
                {
                    if (fileFoto != null)
                    {
                        var evidenciaUpdate = await PersonaProductoEvidenciaRepo.ObtenerEvidenciaPorTipo(idPersonaProducto, "P");
                        if (idPersonaProducto == -1 || evidenciaUpdate==null)
                        {
                            evidenciaFoto.PersonaProductoId = asignacion.Id;
                            evidenciaFoto.NombreArchivo = fileNameFoto;
                            evidenciaFoto.FechaArchivo = DateTime.Now;
                            evidenciaFoto.Tipo = "P";
                            exito = await PersonaProductoEvidenciaRepo.RegistrarEvidencia(evidenciaFoto);
                        }
                        else
                        {
                            
                            evidenciaUpdate.PersonaProductoId = asignacion.Id;
                            evidenciaUpdate.NombreArchivo = fileNameFoto;
                            evidenciaUpdate.FechaArchivo = DateTime.Now;
                            evidenciaUpdate.Tipo = "P";
                            exito = await PersonaProductoEvidenciaRepo.ActualizarEvidencia(evidenciaUpdate);
                        }

                        var filePath = Path.Combine(_env.ContentRootPath + "/Documents/AsignacionPersona/",
                            fileNameFoto);

                        using var stream = System.IO.File.Create(filePath);
                        await fileFoto.CopyToAsync(stream);
                        //exito = await PersonaProductoEvidenciaRepo.RegistrarEvidencia(evidenciaFoto);

                    }

                }
                catch (Exception)
                {

                    exito = false;
                }


            }
            catch (Exception)

            {

                exito = false;
            }

            //llamar metodo para correo 

            return Json(exito);
        }

        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id, bool estado)
        {

            var exito = await PersonaProductoRepo.CambiarEstado(id, !estado);
            return Json(exito);

        }


        public async Task<IActionResult> ObtenerProductoPorPersonaProductoID(int id)
        {
            var producto = await ProductoRepo.ObtenerProductoPorPersonaProductoID(id);
            return Json(producto);
        }


        public async Task<IActionResult> ObtenerClasificacionPorPersonaProductoID(int id)
        {
            var clasificacion = await ClasificacionRepo.ObtenerClasificacionPorPersonaProductoID(id);
            return Json(clasificacion);
        }


        public async Task<IActionResult> Obtener(int id)
        {
            var producto = await PersonaProductoRepo.ObtenerPersonaProductoPorID(id);
            return Json(producto);
        }


        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this._env.ContentRootPath, "Documents/AsignacionPersona/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}






