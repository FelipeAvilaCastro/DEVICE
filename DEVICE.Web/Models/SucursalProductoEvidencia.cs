using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Models
{
    public class SucursalProductoEvidencia
    {

        public int Id { get; set; }
        public int? SucursalProductoId { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime? FechaArchivo { get; set; }
        public string Tipo { get; set; }

        public virtual SucursalProducto SucursalProducto { get; set; }

    }
}
