using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class EquipoPersonaViewModel
    {

        public IEnumerable<Producto> ListadoProducto { get; set; }
        public IEnumerable<Persona> ListadoPersona { get; set; }
    }
}
