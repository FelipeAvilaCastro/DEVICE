using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class FabricanteRepo
    {

        public FabricanteRepo()
        {

        }

        public static async Task<IEnumerable<Fabricante>> ObtenerFabricante()
        {
            using var data = new DeviceDBContext();
            return await data.Fabricante.Where(x => x.Estado == true).ToListAsync();
        }


    }
}
