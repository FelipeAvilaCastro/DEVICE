using System;
using System.Collections.Generic;

#nullable disable

namespace DEVICE.Web.Models
{
    public partial class Software
    {
        public Software()
        {
            Licencia = new HashSet<Licencia>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Licencia> Licencia { get; set; }
    }
}
