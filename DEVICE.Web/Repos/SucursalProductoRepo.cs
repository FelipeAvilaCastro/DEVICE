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
            return await data.SucursalProducto.Include("Sucursal").Include("Producto").Include("SucursalProductoEvidencia").ToListAsync();
        }

        public static async Task<SucursalProducto> ObtenerSucursalProductoPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.SucursalProducto.Include("Sucursal").Include("Producto").Include("SucursalProductoEvidencia").Where(x => x.Id == id).FirstOrDefaultAsync();
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

        public static async Task<bool> ActualizarSucursalProducto(SucursalProducto sucursalProducto)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                var productoNow = data.SucursalProducto.Where(x => x.Id == sucursalProducto.Id).FirstOrDefault();
                productoNow.SucursalId = sucursalProducto.SucursalId;
                productoNow.ProductoId = sucursalProducto.ProductoId;
                productoNow.FechaEntrega = sucursalProducto.FechaEntrega;
                productoNow.Comentario = sucursalProducto.Comentario;

                //data.PersonaProducto.Add(personaProducto);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<bool> CambiarEstado(int id, bool estado)
        {
            using var data = new DeviceDBContext();
           
            var sucursalProducto = await data.SucursalProducto.Where(x => x.Id == id).FirstOrDefaultAsync();
            sucursalProducto.Estado = estado;

            int rowCount = await data.SaveChangesAsync();
            return (rowCount > 0 ? true : false);
        }


    }
}
