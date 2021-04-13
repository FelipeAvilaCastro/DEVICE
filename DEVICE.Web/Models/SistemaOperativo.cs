using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class SistemaOperativo
    {
        public SistemaOperativo()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
