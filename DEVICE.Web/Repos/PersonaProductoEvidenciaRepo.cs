using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class PersonaProductoEvidenciaRepo
    {

        public static string ObtenerNombreArchivo(int id, string tipo)
        {
            using var data = new DeviceDBContext();
            var evidencia = data.PersonaProductoEvidencia
                .Where(x => x.Id == id && x.Tipo==tipo).FirstOrDefault().NombreArchivo;
            return evidencia;
        }



        public static async Task<bool> RegistrarEvidencia(PersonaProductoEvidencia evidencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                await data.PersonaProductoEvidencia.AddAsync(evidencia);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<bool> RegistrarEvidencia(IEnumerable<PersonaProductoEvidencia> evidencias)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                await data.PersonaProductoEvidencia.AddRangeAsync(evidencias);
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
