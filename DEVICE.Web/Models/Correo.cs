using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Models
{
    public class Correo
    {

        public Correo()
        {
            Licencia = new HashSet<Licencia>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Licencia> Licencia { get; set; }



    }
}
