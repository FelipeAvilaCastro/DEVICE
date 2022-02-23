using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class PersonaProducto
    {
        public PersonaProducto()
        {
            PersonaProductoEvidencia = new HashSet<PersonaProductoEvidencia>();
        }

        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int? ProductoId { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public DateTime? FechaProximaCambio { get; set; }
        public int ClasificacionId { get; set; }
        public string Comentario { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaLiberacion { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }
        public virtual ICollection<PersonaProductoEvidencia> PersonaProductoEvidencia { get; set; }
    }
}
