using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ProcesadorVelocidadRepo
    {

        public ProcesadorVelocidadRepo()
        {

        }

        public static async Task<IEnumerable<ProcesadorVelocidad>> ObtenerProcesadorVelocidad()
        {
            using var data = new DeviceDBContext();
            return await data.ProcesadorVelocidad.ToListAsync();
        }



    }
}
