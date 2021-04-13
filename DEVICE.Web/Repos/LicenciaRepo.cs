using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class LicenciaRepo
    {

        public LicenciaRepo()
        {

        }

        public static async Task<IEnumerable<Licencia>> ObtenerLicencia()
        {
            using var data = new DeviceDBContext();
            return await data.Licencia.ToListAsync();

        }



        public static async Task<bool> RegistrarLicencia(Licencia licencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                data.Licencia.Add(licencia);
                await data.SaveChangesAsync();
            }
            catch (Exception message)
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<bool> ActualizarLicencia(Licencia licencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var licenciaActual = data.Licencia.Where(x => x.Id == licencia.Id).FirstOrDefault();
                licenciaActual.Software = licencia.Software;
          


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
