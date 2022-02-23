using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ParteRepo
    {

        public ParteRepo()
        {

        }

        public static async Task<IEnumerable<Parte>> ObtenerParte()
        {
            using var data = new DeviceDBContext();
            return await data.Parte.OrderBy(X => X.NoParte).Where(x => x.Status == true).ToListAsync();
        }

        public static async Task<bool> RegistrarParte(Parte parte)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                parte.Status = true;
                data.Parte.Add(parte);
                await data.SaveChangesAsync();
            }
            catch (Exception)
            {

                exito = false;
            }

            return exito;
        }

        public static async Task<bool> ActualizarParte(Parte parte)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                var ParteActual = data.Parte.Where(x => x.Id == parte.Id).FirstOrDefault();
                ParteActual.Descripcion = parte.Descripcion;
                await data.SaveChangesAsync();
            }
            catch (Exception)
            {

                exito = false;
            }

            return exito;
        }



    }




}
