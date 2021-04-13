using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Zona
    {
        public Zona()
        {
            Sucursal = new HashSet<Sucursal>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
