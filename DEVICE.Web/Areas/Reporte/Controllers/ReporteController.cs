using DEVICE.Web.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Reporte.Controllers
{
    [Area(nameof(Reporte))]
    public class ReporteController : Controller
    {
        public async Task <IActionResult> Index(string activar)
        {
            DataTable dt = new DataTable();
            if (!String.IsNullOrEmpty(activar))
            {
                dt= await ReporteRepo.ObtenerDispositivosPorPersona();
            }
            //return PartialView(listado);
            ViewBag.data = dt;
            return View();
        }
    }
}
