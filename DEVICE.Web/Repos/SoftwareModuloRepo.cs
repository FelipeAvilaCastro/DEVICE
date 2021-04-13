using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class SoftwareModuloRepo
    {

        public SoftwareModuloRepo()
        {

        }

        public static async Task<IEnumerable<SoftwareModulo>> ObtenerModulo()
        {
            using var data = new DeviceDBContext();
            return await data.SoftwareModulo.ToListAsync();
        }
    }
}
