using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class RegistroEquipoViewModel
    {
        public IEnumerable<TipoProducto> ListadoTipoProducto { get; set; }
        public IEnumerable<SistemaOperativo> ListadoSistemaOperativo { get; set; }
        public IEnumerable<Fabricante> ListadoFabricante { get; set; }
        public IEnumerable<Procesador> ListadoProcesador { get; set; }
        public IEnumerable<ProcesadorGeneracion> ListadoProcesadorGeneracion { get; set; }
        public IEnumerable<ProcesadorVelocidad> ListadoProcesadorVelocidad { get; set; }
    }
}
