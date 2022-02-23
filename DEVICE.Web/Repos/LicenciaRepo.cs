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

        public static async Task<Licencia> ObtenerLicenciaPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.Licencia.Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public static async Task<bool> RegistrarLicencia(Licencia licencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                licencia.Estado = "AC";
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
                licenciaActual.SoftwareId = licencia.SoftwareId;
                licenciaActual.SoftwareModuloId = licencia.SoftwareModuloId;
                licenciaActual.SoftwareVersionId = licencia.SoftwareVersionId;
                licenciaActual.NumeroLicenciaTarjeta = licencia.NumeroLicenciaTarjeta;
                licenciaActual.NumeroLicenciaWeb = licencia.NumeroLicenciaWeb;
                licenciaActual.FechaVencimiento = licencia.FechaVencimiento;
                licenciaActual.CorreoId = licencia.CorreoId;
                licenciaActual.Comentario = licencia.Comentario;
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;


        }












        public static async Task<bool> EliminarLicencia(int id)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var licencia = data.Licencia.Where(x => x.Id == id).FirstOrDefault();
                data.Remove(licencia);
                licencia.Estado = "IN";
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
