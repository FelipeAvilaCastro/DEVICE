using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Documento = new HashSet<Documento>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Contacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
