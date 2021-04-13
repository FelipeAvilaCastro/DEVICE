using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class SistemaOperativoRepo
    {


        public SistemaOperativoRepo()
        {

        }

        public static async Task<IEnumerable<SistemaOperativo>> ObtenerSistemaOperativo()
        {
            using var data = new DeviceDBContext();
            return await data.SistemaOperativo.ToListAsync();
        }

    }
}
