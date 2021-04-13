using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public int? Grupo { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
