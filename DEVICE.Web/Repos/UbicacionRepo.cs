using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class UbicacionRepo
    {

        public UbicacionRepo()
        {

        }


        public static async Task<IEnumerable<Ubicacion>> ObtenerUbicacion()
        {
            using var data = new DeviceDBContext();
            return await data.Ubicacion.OrderBy(x=>x.Descripcion).Where(x=>x.Estado== true).ToListAsync();
        }

        public static async Task<bool> RegistrarUbicacion(Ubicacion ubicacion)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                ubicacion.Estado = true;
                data.Ubicacion.Add(ubicacion);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<bool> ActualizarUbicacion(Ubicacion ubicacion)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var ubicacionActual = data.Ubicacion.Where(x => x.ID == ubicacion.ID).FirstOrDefault();
                ubicacionActual.Descripcion = ubicacion.Descripcion;
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<Ubicacion> ObtenerUbicacionPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.Ubicacion.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public static async Task<bool> EliminarUbicacion(int id)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var ubicacion = data.Ubicacion.Where(x => x.ID == id).FirstOrDefault();
                //data.Remove(producto);
                ubicacion.Estado = false;
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<IEnumerable<PersonaUbicacion>> ObtenerUsuarioDisponibleSinUbicacion()
        {
            using var data = new DeviceDBContext();
            return await data.PersonaUbicacion.FromSqlRaw("SP_GET_PRODUCTODISPONIBLE").ToListAsync();
        }




    }
}
