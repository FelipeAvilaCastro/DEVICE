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
                int idSucursal = Convert.ToInt32(Request.Form.Where(x => x.Key == "vSucursal").FirstOrDefault().Value);
                int idEquipo = Convert.ToInt32(Request.Form.Where(x => x.Key == "vEquipo").FirstOrDefault().Value);

                DateTime fechaEntrega = Convert.ToDateTime(Request.Form["vFechaEntrega"]).Date;
                string comentario = Request.Form.Where(x => x.Key == "vComentario").FirstOrDefault().Value;

                var fileFirma = Request.Form.Files.Count == 0 ? null : Request.Form.Files[0];

                string fileNameFirma = Guid.NewGuid().ToString() + Path.GetExtension(fileFirma.FileName).ToLowerInvariant();

                var asignacion = new SucursalProducto()
                {
                    SucursalId = idSucursal,
                    ProductoId = idEquipo,
                    FechaEntrega = fechaEntrega,
                    Estado = true,
                    Comentario = comentario,

                };

                exito = await SucursalProductoRepo.RegistrarSucursalProducto(asignacion);

                

                var evidenciaFirma = new SucursalProductoEvidencia();

                try
                {
                    if (fileFirma != null)
                    {
                        evidenciaFirma.SucursalProductoId = asignacion.Id;
                        evidenciaFirma.NombreArchivo = fileNameFirma;
                        evidenciaFirma.FechaArchivo = DateTime.Now;


                        var filePath = Path.Combine(_env.ContentRootPath + "/Documents/AsignacionSucursal/",
                            fileNameFirma);

                        using var stream = System.IO.File.Create(filePath);
                        await fileFirma.CopyToAsync(stream);

                    }

                    exito = await SucursalProductoEvidenciaRepo.RegistrarEvidencia(evidenciaFirma);

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

    }
}
