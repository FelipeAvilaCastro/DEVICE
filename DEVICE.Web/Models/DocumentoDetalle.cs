using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class DocumentoDetalle
    {
        public int Id { get; set; }
        public int? DocumentoId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
