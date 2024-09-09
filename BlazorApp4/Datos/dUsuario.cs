using BlazorApp4.Components.Pages.Usuarios;
using BlazorApp4.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorApp4.Datos
{
    public class dUsuario
    {
        string cadenaConexion;

        public dUsuario(string cnn)
        {
            cadenaConexion = cnn;
        }

        public async Task<List<mUsuario>?> GetUsuarios() {
            List<mUsuario >? ListadoUsuarios = new List<mUsuario>();
            SqlMapper.Settings.CommandTimeout = 120;
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                ListadoUsuarios = await db.QueryAsync<mUsuario>("GetUsuarios", null, commandType: CommandType.StoredProcedure) as List<mUsuario>;
            }
            return ListadoUsuarios;
        }

        
    }
}
