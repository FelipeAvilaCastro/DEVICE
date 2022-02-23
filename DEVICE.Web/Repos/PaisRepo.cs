using DEVICE.Web.Models;
using DEVICE.Web.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class PaisRepo
    {



        public PaisRepo()
        {

        }



        public static async Task<IEnumerable<Pais>> ObtenerPais()
        {
            using var data = new DeviceDBContext();
            return await data.Pais.ToListAsync();
        }

    }
}