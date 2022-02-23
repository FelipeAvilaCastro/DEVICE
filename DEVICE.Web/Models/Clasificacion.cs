using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Models
{




    public class Clasificacion
    {

        public Clasificacion()
        {
            PersonaProducto = new HashSet<PersonaProducto>();
        }


        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<PersonaProducto> PersonaProducto { get; set; }
    }
}
