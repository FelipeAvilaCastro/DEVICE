using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class ProductoViewModel
    {
        public int ID { get; set; }
        public string NumeroProducto { get; set; }
        public string NumeroSerie { get; set; }

    }

    public class ProductoDescripcionViewModel
    {
        public int ID { get; set; }
        public string NumeroProducto { get; set; }

    }

    public class ProductoSerieViewModel
    {
        public int ID { get; set; }        
        public string NumeroSerie { get; set; }


    }
}
