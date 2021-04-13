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
        public string Descripcion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int? ProveedorId { get; set; }
        public decimal? MontoTotal { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<DocumentoDetalle> DocumentoDetalle { get; set; }
    }
}
