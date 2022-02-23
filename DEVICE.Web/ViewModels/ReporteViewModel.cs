using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class ReporteViewModel
    {

        public IEnumerable<Producto> ListadoVistaGeneralDispositivos { get; set; }

        public DataTable ReportePrueba1 { get; set; }

        public DataTable ReportePrueba2 { get; set; }

    }


}
