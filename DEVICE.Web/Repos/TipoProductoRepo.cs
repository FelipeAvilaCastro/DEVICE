using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class TipoProductoRepo
    {


        public TipoProductoRepo()
        {

        }

        public static async Task<IEnumerable<TipoProducto>> ObtenerTipoProducto()
        {
            using var data = new DeviceDBContext();
            return await data.TipoProducto.Where(x => x.Estado == true).ToListAsync();
        }


    }


}
