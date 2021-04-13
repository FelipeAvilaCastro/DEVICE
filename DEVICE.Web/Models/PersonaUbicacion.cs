using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class PersonaUbicacion
    {
        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int? UbicacionId { get; set; }
        public DateTime? FechaUbicacion { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
    }
}
