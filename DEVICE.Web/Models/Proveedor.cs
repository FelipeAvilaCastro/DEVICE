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
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public int? PaisID { get; set; }
        public int? EstadoID { get; set; }
        public int? CiudadID { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public string SitioWeb { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
