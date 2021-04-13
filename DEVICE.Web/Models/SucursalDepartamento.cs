using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class SucursalDepartamento
    {
        public int Id { get; set; }
        public int? SucursalId { get; set; }
        public int? DepartamentoId { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
