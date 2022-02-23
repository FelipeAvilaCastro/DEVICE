using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class CiudadRepo
    {

        public CiudadRepo()
        {

        }

        public static async Task<IEnumerable<Ciudad>> ObtenerCiudad()
        {
            using var data = new DeviceDBContext();
            return await data.Ciudad.ToListAsync();
        }

    }
}
