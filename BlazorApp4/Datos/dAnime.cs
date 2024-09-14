using BlazorApp4.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorApp4.Datos
{
    public class dAnime
    {
        string cadenaConexion;

        public dAnime(string cnn)
        {
            cadenaConexion = cnn;
        }

        public async Task<List<mAnime>?> GetAnimes()
        {
            List<mAnime>? ListaAnimes = new List<mAnime>();
            SqlMapper.Settings.CommandTimeout = 120;
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                ListaAnimes = await db.QueryAsync<mAnime>("GetAnimes", null, commandType: CommandType.StoredProcedure) as List<mAnime>;
            }
            return ListaAnimes;
        }
    }
}
