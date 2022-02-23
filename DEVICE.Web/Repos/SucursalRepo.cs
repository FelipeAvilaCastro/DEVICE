using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class SucursalRepo
    {

        public SucursalRepo()
        {

        }

        public static async Task<Producto> ObtenerProductoPorSucursalProductoID(int sucursalProductoID)
        {
            using var data = new DeviceDBContext();

            var query = await (from p in data.Producto
                               join sp in data.SucursalProducto on p.Id equals sp.ProductoId
                               where sp.Id == sucursalProductoID
                               select p).FirstOrDefaultAsync();
            return query;
        }



        public static async Task<IEnumerable<Sucursal>> ObtenerSucursal()
        {
            using var data = new DeviceDBContext();
            return await data.Sucursal.ToListAsync();
        }

        public static async Task<Sucursal> ObtenerSucursalPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.Sucursal.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<bool> RegistrarSucursal(Sucursal sucursal)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                data.Sucursal.Add(sucursal);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> EliminarSucursal(int id)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var persona = data.Sucursal.Where(x => x.Id == id).FirstOrDefault();
                //data.Remove(producto);
                //persona.Estado = false;
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> ActualizarSucursal(Sucursal sucursal)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var sucursalActual = data.Sucursal.Where(x => x.Id == sucursal.Id).FirstOrDefault();
                sucursalActual.Descripcion = sucursal.Descripcion;
                sucursalActual.ZonaId = sucursal.ZonaId;



                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


    }

    
}
