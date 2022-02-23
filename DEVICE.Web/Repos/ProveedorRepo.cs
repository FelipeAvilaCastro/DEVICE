using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ProveedorRepo
    {



        public ProveedorRepo()
        {

        }


        public static async Task<IEnumerable<Proveedor>> ObtenerProveedor()
        {
            using var data = new DeviceDBContext();
            return await data.Proveedor.Where(x => x.Status == true).ToListAsync();
        }




        public static async Task<string> RegistrarProveedor(Proveedor proveedor)
        {
            //bool exito = true;
            string exito = "OK";
            try
            {

                using var data = new DeviceDBContext();

                //validar



                proveedor.Status = true;
                proveedor.PaisID = (proveedor.PaisID == -1 ? null : proveedor.PaisID);
                proveedor.EstadoID = (proveedor.EstadoID == -1 ? null : proveedor.EstadoID);
                proveedor.CiudadID = (proveedor.CiudadID == -1 ? null : proveedor.CiudadID);


                data.Proveedor.Add(proveedor);
                await data.SaveChangesAsync();
            }
            catch (Exception message)
            {
                //exito = false;
                exito = "ERROR";
            }
            return exito;
        }


        public static async Task<Proveedor> ObtenerProveedorPorID(int id)
        {
            using var data = new DeviceDBContext();
            return await data.Proveedor.Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public static async Task<string> ActualizarProveedor(Proveedor proveedor)
        {
            string exito = "OK";
            try
            {
                using var data = new DeviceDBContext();
                //bool resultado = await ValidarNumeroSerie(producto.NumeroSerie, producto.Id);
                //if (resultado)
                //    return "El número de serie ya se encuentra registrado.";

                var proveedorActual = data.Proveedor.Where(x => x.Id == proveedor.Id).FirstOrDefault();
                proveedorActual.Nombre = proveedor.Nombre;
                proveedorActual.RFC = proveedor.RFC;
                proveedorActual.RazonSocial = proveedor.RazonSocial;
                proveedorActual.Direccion = proveedor.Direccion;
                proveedorActual.Colonia = proveedor.Colonia;
                proveedorActual.PaisID = proveedor.PaisID;
                proveedorActual.EstadoID = proveedor.EstadoID;
                proveedorActual.CiudadID = proveedor.CiudadID;
                proveedorActual.CodigoPostal = proveedor.CodigoPostal;
                proveedorActual.Email = proveedor.Email;
                proveedorActual.SitioWeb = proveedor.SitioWeb;
                proveedorActual.Contacto = proveedor.Contacto;
                proveedorActual.Telefono = proveedor.Telefono;
                proveedorActual.Observacion = proveedor.Observacion;
                proveedorActual.UsuarioRegistro = proveedor.UsuarioRegistro;
                proveedorActual.FechaRegistro = proveedor.FechaRegistro;

                await data.SaveChangesAsync();
            }
            catch
            {
                exito = "ERROR";
            }
            return exito;
        }


        public static async Task<bool> EliminarProveedor(int id)
        {
            bool exito = true;
            try
            {
                using var data = new DeviceDBContext();

                var proveedor = data.Proveedor.Where(x => x.Id == id).FirstOrDefault();
                //data.Remove(producto);
                proveedor.Status = false;
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
