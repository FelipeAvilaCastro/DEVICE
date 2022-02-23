using DEVICE.Web.Repos;
using DEVICE.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Areas.Administrativo.Controllers
{
    [Area(nameof(Administrativo))]

    [Authorize]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            DataTable dt = await ReporteRepo.VistaGeneralDispositivos();
            //ViewBag.data = dt;


            DataTable dt2 = await ReporteRepo.DispositivosporSucursal();
            //ViewBag.data = dt2;
            //return View();


            var reportesDashboard = new ReporteViewModel()
            {
                ReportePrueba1 = dt,
                ReportePrueba2 = dt2
                

            };
            return View(reportesDashboard);
        }




    }
}
