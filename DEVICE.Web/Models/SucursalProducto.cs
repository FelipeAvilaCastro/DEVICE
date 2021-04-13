using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{




    public partial class SucursalProducto
    {

        public SucursalProducto()
        {
            SucursalProductoEvidencia = new HashSet<SucursalProductoEvidencia>();
        }


        public int Id { get; set; }
        public int? SucursalId { get; set; }
        public int? ProductoId { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public bool Estado { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaLiberacion { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Sucursal Sucursal { get; set; }

        public virtual ICollection<SucursalProductoEvidencia> SucursalProductoEvidencia { get; set; }

    }
}
