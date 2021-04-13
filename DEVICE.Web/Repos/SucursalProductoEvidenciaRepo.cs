using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class SucursalProductoEvidenciaRepo
    {

        public static async Task<bool> RegistrarEvidencia(SucursalProductoEvidencia evidencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                await data.SucursalProductoEvidencia.AddAsync(evidencia);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<bool> RegistrarEvidencia(IEnumerable<SucursalProductoEvidencia> evidencias)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                await data.SucursalProductoEvidencia.AddRangeAsync(evidencias);
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
