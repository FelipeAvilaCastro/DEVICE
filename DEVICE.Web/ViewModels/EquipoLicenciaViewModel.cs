using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class EquipoLicenciaViewModel
    {
        public IEnumerable<Producto> ListadoProducto { get; set; }
        public IEnumerable<Licencia> ListadoLicencia { get; set; }
    }
}
