using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Models
{
    public partial class Parte
    {
        public Parte() 
        {
            DocumentoDetalle = new HashSet<DocumentoDetalle>();
            
        }

        public int Id { get; set; }
        public int NoParte { get; set; }
        public string Descripcion { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        public int Stock { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<DocumentoDetalle> DocumentoDetalle { get; set; }
       
        

    }



}
