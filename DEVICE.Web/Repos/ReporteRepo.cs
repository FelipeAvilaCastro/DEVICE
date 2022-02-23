using DEVICE.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.Repos
{
    public class ReporteRepo
    {

        public static async Task<DataTable> VistaGeneralDispositivos()
        {
            DataTable Tabla = new DataTable();

            using (var context = new DeviceDBContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SP_GET_OVERVIEW";
                command.CommandType = CommandType.StoredProcedure;
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    Tabla.Load(reader);
                }

            }
            return Tabla;
        }



        public static async Task<DataTable> DispositivosporSucursal()
        {
            DataTable Tabla2 = new DataTable();

            using (var context = new DeviceDBContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SP_GET_OVERVIEW_BY_BRANCH";
                command.CommandType = CommandType.StoredProcedure;
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    Tabla2.Load(reader);
                }

            }
            return Tabla2;
        }




        public static async Task<DataTable> ObtenerDispositivosPorPersona()
        {
            DataTable Tabla = new DataTable();

            using (var context = new DeviceDBContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "REPORTEUSUARIO";
                command.CommandType = CommandType.StoredProcedure;
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    Tabla.Load(reader);
                }

            }
            return Tabla;
        }




    }
}
