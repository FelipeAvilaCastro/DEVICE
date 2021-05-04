using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
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

        public static async Task<PersonaProductoEvidencia> ObtenerEvidenciaPorTipo(int idPersonaProducto, string tipo)
        {
            using var data = new DeviceDBContext();
            var evidencia = await data.PersonaProductoEvidencia
                .Where(x => x.PersonaProductoId == idPersonaProducto && x.Tipo == tipo).FirstOrDefaultAsync();
            return evidencia;
        }

        public static async Task<IEnumerable<PersonaProductoEvidencia>> ObtenerEvidencia(int idPersonaProducto)
        {
            using var data = new DeviceDBContext();
            var evidencia = await data.PersonaProductoEvidencia
                .Where(x => x.PersonaProductoId== idPersonaProducto).ToListAsync();
            return evidencia;
        }

        public static async Task<bool> ActualizarEvidencia(PersonaProductoEvidencia evidencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                var evidenciaNow = data.PersonaProductoEvidencia.Where(x => x.PersonaProductoId == evidencia.PersonaProductoId && x.Tipo==evidencia.Tipo).FirstOrDefault();
                evidenciaNow.PersonaProductoId = evidencia.PersonaProductoId;
                evidenciaNow.NombreArchivo = evidencia.NombreArchivo;
                evidenciaNow.FechaArchivo = evidencia.FechaArchivo;
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
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
