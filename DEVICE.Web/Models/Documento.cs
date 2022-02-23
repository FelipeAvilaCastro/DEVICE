using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Documento
    {
        public Documento()
        {
            DocumentoDetalle = new HashSet<DocumentoDetalle>();
        }

        public int Id { get; set; }
        public int RD { get; set; }
        public string DocumentoEncabezado { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public int? ProveedorId { get; set; }
        public string Observaciones { get; set; }
        public string Status { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<DocumentoDetalle> DocumentoDetalle { get; set; }
    }
}
