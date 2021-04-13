using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ProcesadorGeneracionRepo
    {
        public ProcesadorGeneracionRepo()
        {

        }

        public static async Task<IEnumerable<ProcesadorGeneracion>> ObtenerProcesadorGeneracion()
        {
            using var data = new DeviceDBContext();
            return await data.ProcesadorGeneracion.ToListAsync();
        }

    }
}
