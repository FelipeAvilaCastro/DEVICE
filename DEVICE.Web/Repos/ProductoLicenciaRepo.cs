using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ProductoLicenciaRepo
    {

        public static async Task<IEnumerable<ProductoLicencia>> ObtenerProductoLicencia()
        {
            using var data = new DeviceDBContext();
            return await data.ProductoLicencia.Include("Producto").Include("Licencia").ToListAsync();
        }


        public static async Task<bool> RegistrarProductoLicencia(ProductoLicencia productoLicencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                productoLicencia.Estado = true;
                data.ProductoLicencia.Add(productoLicencia);
                await data.SaveChangesAsync();
            }
            catch (Exception message)
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<bool> ActualizarProductoLicencia(ProductoLicencia productoLicencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                var productoNow = data.ProductoLicencia.Where(x => x.Id == productoLicencia.Id).FirstOrDefault();
                productoNow.ProductoId = productoLicencia.ProductoId;
                productoNow.LicenciaId = productoLicencia.LicenciaId;
                productoNow.FechaConfiguracion = productoLicencia.FechaConfiguracion;

                //data.PersonaProducto.Add(personaProducto);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<ProductoLicencia> ObtenerProductoLicenciaPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.ProductoLicencia.Include("Producto").Include("Licencia").Include("ProductoLicenciaEvidencia").Where(x => x.Id == id).FirstOrDefaultAsync();
        }


    }
}
