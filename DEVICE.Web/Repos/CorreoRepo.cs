using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class CorreoRepo
    {


        public CorreoRepo()
        {

        }

        public static async Task<IEnumerable<Correo>> ObtenerCorreo()
        {
            using var data = new DeviceDBContext();
            return await data.Correo.ToListAsync();
        }


    }
}
