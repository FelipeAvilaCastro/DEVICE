using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class EquipoFabricanteViewModel
    {
        public IEnumerable<Producto> ListadoProducto { get; set; }

        public IEnumerable<Fabricante> ListadoFabricante { get; set; }

        public IEnumerable<TipoProducto> ListadoTipoProducto { get; set; }
    }
}
