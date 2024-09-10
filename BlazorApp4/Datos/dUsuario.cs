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

        public async Task<mResponse> CreateUsuarios(mUsuario usuario)
        {
            int resultado;
            try
            {
                SqlMapper.Settings.CommandTimeout = 120;
                using (IDbConnection db = new SqlConnection(cadenaConexion))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@Nombre", usuario.Nombre);
                    parametros.Add("@Correo", usuario.Correo);
                    parametros.Add("@IdDepartamento", usuario.Departamento);
                    parametros.Add("@Sueldo", usuario.Sueldo);
                    parametros.Add("@Resultado", DbType.Int64, direction: ParameterDirection.Output);
                    await db.ExecuteAsync("CreateUsuarios", parametros, commandType: CommandType.StoredProcedure);
                    resultado = parametros.Get<int>("@Resultado");
                }
                if (resultado != 0)
                {
                    return new mResponse()
                    {
                        error = false,
                        message = ""
                    };

                }
                else
                {
                    return new mResponse()
                    {
                        error = false,
                        message = "No se realizo el registro"
                    };
                }

            }
            catch (Exception e)
            {
                return new mResponse()
                {
                    error = true,
                    message = e.Message
                };

            }

        }

        public async Task<mResponse> UpdateUsuario(mUsuario usuario)
        {
            int resultado;

            try
            {
                SqlMapper.Settings.CommandTimeout = 120;
                using (IDbConnection db = new SqlConnection(cadenaConexion))
                { 
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id",usuario.Usuarioid);
                    parameters.Add("@Nombre",usuario.Nombre);
                    parameters.Add("@Correo",usuario.Correo);
                    parameters.Add("@IdDepartamento",usuario.Departamento);
                    parameters.Add("@Sueldo",usuario.Sueldo);
                    parameters.Add("@Fecharegistro",usuario.Fecharegistro);
                    parameters.Add("@Resultado",DbType.Int64,direction: ParameterDirection.Output);
                    await db.ExecuteAsync("UpdateUsuario", parameters, commandType: CommandType.StoredProcedure);
                    resultado = parameters.Get<int>("@Resultado");
                }
                if (resultado != 0)
                {
                    return new mResponse()
                    {
                        error = false,
                        message = "El usuario se ha actualizado"
                    };
                }
                else
                {
                    return new mResponse()
                    {
                        error = true,
                        message = ""
                    };
                }

            }
            catch (Exception e)
            {

                return new mResponse()
                {
                    error = true,
                    message = e.Message
                };
            }
        }

        public async Task<mResponse> DeleteUsuario(mUsuario usuario)
        {
            int resultado;
            try
            {
                using (IDbConnection db = new SqlConnection(cadenaConexion))
                {
                    SqlMapper.Settings.CommandTimeout = 120;
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", usuario.Usuarioid);
                    parameters.Add("@Resultado", DbType.Int64, direction: ParameterDirection.Output);
                    await db.ExecuteAsync("DeleteUsuario", parameters, commandType: CommandType.StoredProcedure);
                    resultado = parameters.Get<int>("@Resultado");

                    if (resultado != 0)
                    {
                        return new mResponse
                        {
                            error = false,
                            message = "El usuario se ha eliminado"
                        };
                    }
                    else
                    {
                        return new mResponse
                        {
                            error = true,
                            message = "Hubo un error al eliminar al empleado"
                        };
                    }
                }
            }
            catch (Exception e)
            {

                return new mResponse
                {
                    error = true,
                    message = e.Message
                };
            }
            
        }
    }
}
