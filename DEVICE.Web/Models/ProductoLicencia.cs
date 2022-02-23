using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class ProductoLicencia
    {

        public ProductoLicencia()
        {
            ProductoLicenciaEvidencia = new HashSet<ProductoLicenciaEvidencia>();
        }


        public int Id { get; set; }
        public int? ProductoId { get; set; }
        public int? LicenciaId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaConfiguracion { get; set; }
        public DateTime? FechaDesinstalacion { get; set; }

        public virtual Licencia Licencia { get; set; }
        public virtual Producto Producto { get; set; }

        public virtual ICollection<ProductoLicenciaEvidencia> ProductoLicenciaEvidencia { get; set; }

    }
}
