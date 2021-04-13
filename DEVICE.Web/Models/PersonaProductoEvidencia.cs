using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class PersonaProductoEvidencia
    {
        public int Id { get; set; }
        public int? PersonaProductoId { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime? FechaArchivo { get; set; }
        public string Tipo { get; set; }

        public virtual PersonaProducto PersonaProducto { get; set; }
    }
}
