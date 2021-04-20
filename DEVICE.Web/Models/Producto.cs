using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DocumentoDetalle = new HashSet<DocumentoDetalle>();
            PersonaProducto = new HashSet<PersonaProducto>();
            ProductoLicencia = new HashSet<ProductoLicencia>();
            SucursalProducto = new HashSet<SucursalProducto>();
        }

        public int Id { get; set; }
        public string Comentario { get; set; }
        public int? TipoProductoId { get; set; }
        public string NumeroSerie { get; set; }
        public string NumeroProducto { get; set; }
        public int? MemoriaRam { get; set; }
        public string Modelo { get; set; }
        public int? SistemaOperativoId { get; set; }
        public int? FabricanteId { get; set; }
        public int? ProcesadorId { get; set; }
        public int? ProcesadorGeneracionId { get; set; }
        public int? ProcesadorVelocidadId { get; set; }
        public string Estado { get; set; }
        public string Ip { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Ssidnombre { get; set; }
        public string Ssidpassword { get; set; }

        public virtual Fabricante Fabricante { get; set; }
        public virtual Procesador Procesador { get; set; }
        public virtual SistemaOperativo SistemaOperativo { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
        public virtual ICollection<DocumentoDetalle> DocumentoDetalle { get; set; }
        public virtual ICollection<PersonaProducto> PersonaProducto { get; set; }
        public virtual ICollection<ProductoLicencia> ProductoLicencia { get; set; }
        public virtual ICollection<SucursalProducto> SucursalProducto { get; set; }
    }
}
