using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class RegistroProveedorViewModel
    {
        public IEnumerable<Proveedor> ListadoProveedor { get; set; }
        public IEnumerable<Pais> ListadoPais { get; set; }
        public IEnumerable<Estado> ListadoEstado { get; set; }
        public IEnumerable<Ciudad> ListadoCiudad { get; set; }

    }
}
