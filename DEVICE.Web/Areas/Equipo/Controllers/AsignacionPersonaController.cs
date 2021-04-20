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
                ListadoProducto = await ProductoRepo.ObtenerProductoDisponible()

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

                int idEquipo = Convert.ToInt32(Request.Form.Where(x => x.Key == "vEquipo").FirstOrDefault().Value);
                int idPersona = Convert.ToInt32(Request.Form.Where(x => x.Key == "vPersona").FirstOrDefault().Value);

                DateTime fechaEntrega = Convert.ToDateTime(Request.Form["vFechaEntrega"]).Date;
                DateTime fechaProximoCambio = Convert.ToDateTime(Request.Form["vFechaProximoCambio"]).Date;
                string comentario = Request.Form.Where(x => x.Key == "vComentario").FirstOrDefault().Value;
                
                
                var fileFirma = Request.Form.Files.Count == 0 ? null : Request.Form.Files[0];
                var fileFoto = Request.Form.Files.Count == 0 ? null : Request.Form.Files[1];


                string fileNameFirma = Guid.NewGuid().ToString() + Path.GetExtension(fileFirma.FileName).ToLowerInvariant();
                string fileNameFoto = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fileFoto.FileName).ToLowerInvariant();

                var asignacion = new PersonaProducto()
                {
                    PersonaId = idPersona,
                    ProductoId = idEquipo,
                    FechaProximaCambio = fechaEntrega,
                    FechaEntrega = fechaProximoCambio,
                    Comentario = comentario,
                    Estado = true
                };

                exito = await PersonaProductoRepo.RegistrarPersonaProducto(asignacion);



                var evidenciaFirma = new PersonaProductoEvidencia();
                var evidenciaFoto = new PersonaProductoEvidencia();

                try
                {
                    if (fileFirma != null)
                    {
                        evidenciaFirma.PersonaProductoId = asignacion.Id;
                        evidenciaFirma.NombreArchivo = fileNameFirma;
                        evidenciaFirma.FechaArchivo = DateTime.Now;
                        evidenciaFirma.Tipo = "S";

                        var filePath = Path.Combine(_env.ContentRootPath + "/Documents/AsignacionPersona/",
                            fileNameFirma);

                        using var stream = System.IO.File.Create(filePath);
                        await fileFirma.CopyToAsync(stream);
                    }

                    exito = await PersonaProductoEvidenciaRepo.RegistrarEvidencia(evidenciaFirma);
                }
                catch (Exception)
                {

                    exito = false;
                }



                try
                {
                    if (fileFoto != null)
                    {
                        evidenciaFoto.PersonaProductoId = asignacion.Id;
                        evidenciaFoto.NombreArchivo = fileNameFoto;
                        evidenciaFoto.FechaArchivo = DateTime.Now;
                        evidenciaFoto.Tipo = "P";

                        var filePath = Path.Combine(_env.ContentRootPath + "/Documents/AsignacionPersona/",
                            fileNameFoto);

                        using var stream = System.IO.File.Create(filePath);
                        await fileFoto.CopyToAsync(stream);
                    }

                    exito = await PersonaProductoEvidenciaRepo.RegistrarEvidencia(evidenciaFoto);
                }
                catch (Exception)
                {

                    exito = false;
                }


            }
            catch (Exception )
            
            {
               
                exito = false;
            }

            return Json(exito);
        }

        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id,bool estado) {

            var exito = await PersonaProductoRepo.CambiarEstado(id, !estado);
            return Json(exito);

        }

        public IActionResult PruebaDT() {
            return View();
        }
    }
}






