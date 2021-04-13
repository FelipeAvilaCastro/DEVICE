using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Persona
    {
        public Persona()
        {
            PersonaProducto = new HashSet<PersonaProducto>();
            PersonaUbicacion = new HashSet<PersonaUbicacion>();
        }

        public int Id { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Puesto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<PersonaProducto> PersonaProducto { get; set; }
        public virtual ICollection<PersonaUbicacion> PersonaUbicacion { get; set; }
    }
}
