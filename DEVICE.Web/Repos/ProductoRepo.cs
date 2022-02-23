using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ProductoRepo
    {
        public ProductoRepo()
        {

        }

        public static async Task<Producto> ObtenerProductoPorPersonaProductoID(int personaProductoID)
        {
            using var data = new DeviceDBContext();

            var query = await (from p in data.Producto
                         join pp in data.PersonaProducto on p.Id equals pp.ProductoId
                         where pp.Id == personaProductoID
                         select p).FirstOrDefaultAsync();


            return query;
        }


        public static async Task<Producto> ObtenerProductoPorProductoLicenciaID(int productoLicenciaID)
        {
            using var data = new DeviceDBContext();

            var query = await (from p in data.Producto
                               join pl in data.ProductoLicencia on p.Id equals pl.ProductoId
                               where pl.Id == productoLicenciaID
                               select p).FirstOrDefaultAsync();
            return query;
        }



        public static async Task<IEnumerable<Producto>> ObtenerProductoDisponible()
        {
            using var data = new DeviceDBContext();
            return await data.Producto.FromSqlRaw("SP_GET_PRODUCTODISPONIBLE").ToListAsync();
        }

        public static async Task<IEnumerable<Producto>> ObtenerProductoDisponibleSucursal()
        {
            using var data = new DeviceDBContext();
            return await data.Producto.FromSqlRaw("SP_GET_PRODUCTODISPONIBLESUCURSAL").ToListAsync();
        }

        public static async Task<IEnumerable<Producto>> ObtenerLicenciaDisponible()
        {
            using var data = new DeviceDBContext();
            return await data.Producto.FromSqlRaw("SP_GET_LICENCIADISPONIBLE").ToListAsync();
        }


        public static async Task<IEnumerable<Producto>> ObtenerProducto()
        {
            using var data = new DeviceDBContext();
            return await data.Producto.Include("TipoProducto").Where(x => x.Estado == "AC").ToListAsync();
        }

        public static async Task<Producto> ObtenerProductoPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.Producto.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<string> RegistrarProducto(Producto producto)
        {
            string exito = "OK";

            try
            {
                using var data = new DeviceDBContext();

                bool resultado = await ValidarNumeroSerie(producto.NumeroSerie,null);
                if (resultado)
                    return "El número de serie ya se encuentra registrado.";
                //si es que capturo impresoras sin numero de serie no validarla ?


                producto.Estado = "AC";
                producto.SistemaOperativoId = (producto.SistemaOperativoId == -1 ? null : producto.SistemaOperativoId);
                producto.FabricanteId = (producto.FabricanteId == -1 ? null : producto.FabricanteId);
                producto.ProcesadorId = (producto.ProcesadorId == -1 ? 4 : producto.ProcesadorId);
                producto.ProcesadorGeneracionId = (producto.ProcesadorGeneracionId == -1 ? null : producto.ProcesadorGeneracionId);
                producto.ProcesadorVelocidadId = (producto.ProcesadorVelocidadId == -1 ? null : producto.ProcesadorVelocidadId);
                producto.TipoDDID = (producto.TipoDDID == -1 ? null : producto.TipoDDID);
                producto.CapacidadDD = (producto.CapacidadDD == -1 ? null : producto.CapacidadDD);
                data.Producto.Add(producto);
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = "ERROR";
            }
            return exito;
        }

        public static async Task<bool> EliminarProducto(int id)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var producto = data.Producto.Where(x => x.Id == id).FirstOrDefault();
                //data.Remove(producto);
                producto.Estado = "IN";
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> ValidarNumeroSerie(string numeroSerie, int? id)
        {
            bool existe = false;
            try
            {
                using var data = new DeviceDBContext();
                if (id != null)
                {
                    var producto = await data.Producto.Where(x => x.Id == id).FirstOrDefaultAsync();
                    existe = producto.NumeroSerie == numeroSerie ? false : true;

                    existe = await data.Producto.AnyAsync(x => x.NumeroSerie == numeroSerie
                            && x.Id != id) ? true : false;
                    return existe;

                }

                existe = await data.Producto.AnyAsync(x => x.NumeroSerie == numeroSerie 
                && x.Id!=id) ? true : false;            

            }
            catch
            {
                existe = false;
            }
            return existe;
        }

        public static async Task<string> ActualizarProducto(Producto producto)
        {
            string exito = "OK";
            try
            {
                using var data = new DeviceDBContext();
                bool resultado = await ValidarNumeroSerie(producto.NumeroSerie, producto.Id);
                if (resultado)
                    return "El número de serie ya se encuentra registrado.";

                var productoActual = data.Producto.Where(x => x.Id == producto.Id).FirstOrDefault();
                productoActual.Comentario = producto.Comentario;
                productoActual.TipoProductoId = producto.TipoProductoId;
                productoActual.NumeroSerie = producto.NumeroSerie;
                productoActual.NumeroProducto = producto.NumeroProducto;
                productoActual.MemoriaRam = producto.MemoriaRam;
                productoActual.Modelo = producto.Modelo;
                productoActual.SistemaOperativoId = producto.SistemaOperativoId;
                productoActual.FabricanteId = producto.FabricanteId;
                productoActual.ProcesadorId = producto.ProcesadorId;
                productoActual.ProcesadorGeneracionId = producto.ProcesadorGeneracionId;
                productoActual.ProcesadorVelocidadId = producto.ProcesadorVelocidadId;
                productoActual.Ip = producto.Ip;
                productoActual.Usuario = producto.Usuario;
                productoActual.Password = producto.Password;
                productoActual.Ssidnombre = producto.Ssidnombre;
                productoActual.Ssidpassword = producto.Ssidpassword;

                productoActual.NombreEquipo = producto.NombreEquipo;
                productoActual.TipoDDID = producto.TipoDDID;
                productoActual.CapacidadDD = producto.CapacidadDD;
                productoActual.FechaLimiteGarantia = producto.FechaLimiteGarantia;
                await data.SaveChangesAsync();
            }
            catch
            {
                exito = "ERROR";
            }
            return exito;
        }





    }
}