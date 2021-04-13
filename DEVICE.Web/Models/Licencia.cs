using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Licencia
    {
        public Licencia()
        {
            ProductoLicencia = new HashSet<ProductoLicencia>();
        }

        public int Id { get; set; }
        public int? SoftwareId { get; set; }
        public int? SoftwareModuloId { get; set; }
        public int? SoftwareVersionId { get; set; }
        public string NumeroLicenciaTarjeta { get; set; }
        public string NumeroLicenciaWeb { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Comentario { get; set; }
        
        public virtual Software Software { get; set; }

        public virtual ICollection<ProductoLicencia> ProductoLicencia { get; set; }
    }
}
