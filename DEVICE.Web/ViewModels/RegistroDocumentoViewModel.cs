using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class RegistroDocumentoViewModel
    {
        public IEnumerable<Proveedor> ListadoProveedor { get; set; }
        public IEnumerable<Documento> ListadoDocumento { get; set; }
        public IEnumerable<Producto> ListadoProducto { get; set; }
        public IEnumerable<TipoProducto> ListadoTipoProducto { get; set; }

    }
}
