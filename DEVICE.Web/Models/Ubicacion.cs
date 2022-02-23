using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            PersonaUbicacion = new HashSet<PersonaUbicacion>();
        }

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<PersonaUbicacion> PersonaUbicacion { get; set; }
    }
}
