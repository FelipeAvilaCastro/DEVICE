using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class RegistroUsuarioViewModel
    {

        public IEnumerable<Persona> ListadoPersona{ get; set; }
        public IEnumerable<Departamento> ListadoDepartamento { get; set; }
        public IEnumerable<Sucursal> ListadoSucursal { get; set; }

    }
}
