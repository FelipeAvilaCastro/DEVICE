using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class TipoDDRepo
    {

        public TipoDDRepo()
        {

        }

        public static async Task<IEnumerable<TipoDD>> ObtenerTipoDD()
        {
            using var data = new DeviceDBContext();
            return await data.TipoDD.OrderBy(z => z.Descripcion).Where(x => x.Status == true).ToListAsync();
        }


    }
}
