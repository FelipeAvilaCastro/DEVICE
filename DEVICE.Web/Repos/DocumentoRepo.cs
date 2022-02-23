using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class DocumentoRepo
    {
        public static async Task<bool> RegistrarDocumento(Documento documento)
        {
            bool exito = true;
            //string exito = "OK";
            try
            {
                using var data = new DeviceDBContext();
                documento.Status = "AC";
                data.Documento.Add(documento);
                await data.SaveChangesAsync();
            }
            catch (Exception message)
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<bool> ActualizarDocumento(Documento documento)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
  
                await data.SaveChangesAsync();
            }
            catch (Exception message)
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<IEnumerable<Documento>> ObtenerDocumento()
        {
            using var data = new DeviceDBContext();
            return await data.Documento.OrderBy(z => z.RD).Where(x => x.Status== "AC").ToListAsync();
        }


    }


}
