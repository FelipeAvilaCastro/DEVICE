using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            SucursalDepartamento = new HashSet<SucursalDepartamento>();
            Ubicacion = new HashSet<Ubicacion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<SucursalDepartamento> SucursalDepartamento { get; set; }
        public virtual ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
