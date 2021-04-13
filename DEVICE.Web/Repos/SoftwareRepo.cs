using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class SoftwareRepo
    {

        public SoftwareRepo()
        {

        }

        public static async Task<IEnumerable<Software>> ObtenerSoftware()
        {
            using var data = new DeviceDBContext();
            return await data.Software.ToListAsync();
        }

    }
}
