using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class DepartamentoRepo
    {

        public DepartamentoRepo()
        {

        }


        public static async Task<IEnumerable<Departamento>> ObtenerDepartamento()
        {
            using var data = new DeviceDBContext();
            return await data.Departamento.OrderBy(X=> X.Descripcion).Where(x => x.Estado == true).ToListAsync();
        }


        public static async Task<bool> RegistrarDepartamento(Departamento departamento)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();
                departamento.Estado = true;
                data.Departamento.Add(departamento);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> ActualizarDepartamento(Departamento departamento)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var departamentoActual = data.Departamento.Where(x => x.Id == departamento.Id).FirstOrDefault();
                departamentoActual.Descripcion = departamento.Descripcion;
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


        public static async Task<Departamento> ObtenerDepartamentoPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.Departamento.Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public static async Task<bool> EliminarDepartamento(int id)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var departamento = data.Departamento.Where(x => x.Id == id).FirstOrDefault();
                //data.Remove(producto);
                departamento.Estado = false;
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
