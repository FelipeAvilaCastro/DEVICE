using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class PersonaRepo
    {

        public static async Task<IEnumerable<Persona>> ObtenerPersona()
        {
            using var data = new DeviceDBContext();
            return await data.Persona.OrderBy(z=> z.Usuario).Where(x => x.Estado == true).ToListAsync();
        }


        public static async Task<Persona> GetPersonaPorCredenciales(string usuario, string password)
        {
            using var data = new DeviceDBContext();
            return await data.Persona.Where(z => z.Usuario == usuario && z.Password == password).FirstOrDefaultAsync();
        }


        public static async Task<Persona> ObtenerPersonaPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.Persona.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<bool> RegistrarPersona(Persona persona)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                persona.Estado = true;
                data.Persona.Add(persona);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> EliminarPersona(int id)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var persona = data.Persona.Where(x => x.Id == id).FirstOrDefault();
                //data.Remove(producto);
                persona.Estado = false;
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> ActualizarPersona(Persona persona)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var personaActual = data.Persona.Where(x => x.Id == persona.Id).FirstOrDefault();
                personaActual.Paterno = persona.Paterno;
                personaActual.Materno = persona.Materno;
                personaActual.Nombres = persona.Nombres;
                personaActual.Usuario = persona.Usuario;
                personaActual.Clave = persona.Clave;
                personaActual.Password = persona.Password;
                personaActual.DepartamentoID = persona.DepartamentoID;
                personaActual.Puesto = persona.Puesto;
                personaActual.SucursalID = persona.SucursalID;
                personaActual.Telefono = persona.Telefono;
                personaActual.Correo = persona.Correo;


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