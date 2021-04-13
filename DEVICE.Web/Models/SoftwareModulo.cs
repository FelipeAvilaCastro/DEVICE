using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Models
{
    public class SoftwareModulo
    {

        public SoftwareModulo()
        {
            Licencia = new HashSet<Licencia>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Licencia> Licencia { get; set; }
    }
}
