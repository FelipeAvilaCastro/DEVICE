using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
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

        public static async Task<SucursalProductoEvidencia> ObtenerEvidenciaPorTipo(int idSucursalProducto, string tipo)
        {
            using var data = new DeviceDBContext();
            var evidencia = await data.SucursalProductoEvidencia
                .Where(x => x.SucursalProductoId == idSucursalProducto && x.Tipo == tipo).FirstOrDefaultAsync();
            return evidencia;
        }


        public static async Task<bool> ActualizarEvidencia(SucursalProductoEvidencia evidencia)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                var evidenciaNow = data.SucursalProductoEvidencia.Where(x => x.SucursalProductoId == evidencia.SucursalProductoId && x.Tipo == evidencia.Tipo).FirstOrDefault();
                evidenciaNow.SucursalProductoId = evidencia.SucursalProductoId;
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

    }
}
