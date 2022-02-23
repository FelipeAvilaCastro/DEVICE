using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ProcesadorRepo
    {

        public ProcesadorRepo()
        {

        }

        public static async Task<IEnumerable<Procesador>> ObtenerProcesador()
        {
            using var data = new DeviceDBContext();
            return await data.Procesador.OrderBy(z => z.Descripcion).ToListAsync();
        }


    }
}
