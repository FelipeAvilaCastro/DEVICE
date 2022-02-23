using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class PersonaUbicacionRepo
    {

        public PersonaUbicacionRepo()
        {

        }


        public static async Task<bool> RegistrarPersonaUbicacion(PersonaUbicacion personaUbicacion)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                data.PersonaUbicacion.Add(personaUbicacion);
                await data.SaveChangesAsync();
            }

            catch

            {
                exito = false;
            }
            return exito;
        }


        public static async Task<IEnumerable<PersonaUbicacion>> ObtenerPersonaUbicacion()
        {
            using var data = new DeviceDBContext();
            return await data.PersonaUbicacion.ToListAsync();

        }

    }
}
