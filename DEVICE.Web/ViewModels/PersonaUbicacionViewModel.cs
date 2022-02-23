using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class PersonaUbicacionViewModel
    {
        public IEnumerable<PersonaUbicacion> ListadoPersonaUbicacion { get; set; }
        public IEnumerable<Persona> ListadoPersona { get; set; }
        public IEnumerable<Ubicacion> ListadoUbicacion{ get; set; }
        

    }
}
