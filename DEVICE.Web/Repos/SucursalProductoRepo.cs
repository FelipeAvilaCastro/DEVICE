using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class SucursalProductoRepo
    {

        public static async Task<IEnumerable<SucursalProducto>> ObtenerSucursalProducto()
        {
            using var data = new DeviceDBContext();
            return await data.SucursalProducto.Include("Sucursal").Include("Producto").ToListAsync();
        }

        public static async Task<SucursalProducto> ObtenerSucursalProductoPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.SucursalProducto.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<bool> RegistrarSucursalProducto(SucursalProducto sucursalProducto)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                sucursalProducto.Estado = true;
                data.SucursalProducto.Add(sucursalProducto);
                await data.SaveChangesAsync();
            }
            catch (Exception message)
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> CambiarEstado(int id, bool estado)
        {
            using var data = new DeviceDBContext();
            //var personaProducto = await data.PersonaProducto.Where(x => x.Id == id).FirstOrDefault();
            var personaProducto = await data.PersonaProducto.Where(x => x.Id == id).FirstOrDefaultAsync();
            personaProducto.Estado = estado;

            int rowCount = await data.SaveChangesAsync();
            return (rowCount > 0 ? true : false);

        }


    }
}
