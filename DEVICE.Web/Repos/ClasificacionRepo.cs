using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ClasificacionRepo
    {

        public ClasificacionRepo()
        {

        }

        public static async Task<IEnumerable<Clasificacion>> ObtenerClasificacion()
        {
            using var data = new DeviceDBContext();
            return await data.Clasificacion.ToListAsync();
        }



        public static async Task<Clasificacion> ObtenerClasificacionPorPersonaProductoID(int clasificacionProductoID)
        {
            using var data = new DeviceDBContext();

            var query = await (from c in data.Clasificacion
                               join pp in data.PersonaProducto on c.Id equals pp.ClasificacionId
                               where pp.Id == clasificacionProductoID
                               select c).FirstOrDefaultAsync();


            return query;
        }


    }
}
