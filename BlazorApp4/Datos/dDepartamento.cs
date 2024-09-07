using BlazorApp4.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorApp4.Datos
{
    public class dDepartamento
    {
        string cadenaConexion;
        public dDepartamento(string cnn)
        {
            cadenaConexion = cnn;
        }

        public async Task<List<mDepartamento>?> GetDepartamentos()
        {
            List<mDepartamento>? ListadoDepartamento = new List<mDepartamento>();
            SqlMapper.Settings.CommandTimeout = 120;
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                ListadoDepartamento = await db.QueryAsync<mDepartamento>("GetDepartamentos", null, commandType: CommandType.StoredProcedure) as List<mDepartamento>;
            }
            return ListadoDepartamento;
        }

        public async Task<mResponse> CreateDepartamento(mDepartamento departament)
        {
            int id;
            try
            {
                SqlMapper.Settings.CommandTimeout = 120;
                using (IDbConnection db = new SqlConnection(cadenaConexion))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@NombreDepartamento", departament.Nombre);
                    parametros.Add("@IdDepartamento", DbType.Int64, direction: ParameterDirection.Output);
                    await db.ExecuteAsync("CreateDepartamento", parametros, commandType: CommandType.StoredProcedure);
                    id = parametros.Get<int>("@IdDepartamento");
                }
                if (id != 0)
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

        public async Task<mResponse> UpdateDepartamento(mDepartamento departament)
        {
            int id;
            try
            {
                SqlMapper.Settings.CommandTimeout = 120;
                using (IDbConnection db = new SqlConnection(cadenaConexion))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@idDepartamento", departament.Departamentoid);
                    parametros.Add("@Id", DbType.Int64, direction: ParameterDirection.Output);
                    await db.ExecuteAsync("UpdateDepartamento", parametros, commandType: CommandType.StoredProcedure);
                    id = parametros.Get<int>("@Id");
                }
                if (id != 0)
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



        public async Task<mResponse> DeleteDepartamento(mDepartamento departament)
        {
            int id;
            try
            {
                SqlMapper.Settings.CommandTimeout = 120;
                using (IDbConnection db = new SqlConnection(cadenaConexion))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@idDepartamento", departament.Departamentoid);
                    parametros.Add("@Id", DbType.Int64, direction: ParameterDirection.Output);
                    await db.ExecuteAsync("DeleteDepartamento", parametros, commandType: CommandType.StoredProcedure);
                    id = parametros.Get<int>("@Id");
                }
                if (id != 0)
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


        //public async Task<int> Post(eSolicitudFiniquito solicitudFiniquito)
        //    {
        //    int Respuesta = 0;
        //    await Task.Run(() =>
        //    {
        //        using (IDbConnection db = new SqlConnection(sConexion))
        //        {
        //            if (db.State == ConnectionState.Closed)
        //                db.Open();

        //            DynamicParameters parametros = new DynamicParameters();
        //            parametros.Add("@Id", solicitudFiniquito.Id);
        //            parametros.Add("@empleadoId", solicitudFiniquito.EmpleadoId);
        //            parametros.Add("@eliminado", solicitudFiniquito.Eliminado);
        //            parametros.Add("@usuarioCreacion", solicitudFiniquito.UsuarioCreacion);
        //            parametros.Add("@usuarioModificado", solicitudFiniquito.usuarioModifica);
        //            parametros.Add("@ultimoDiaLaborado", solicitudFiniquito.UltimoDiaLaborado.Value);
        //            parametros.Add("@diasPendientes", solicitudFiniquito.DiasPendientes);
        //            parametros.Add("@descansosPendientes", solicitudFiniquito.DescansosPendientes);
        //            parametros.Add("@totalDiasAPagar", solicitudFiniquito.TotalDiasAPagar);
        //            parametros.Add("@comentarios", solicitudFiniquito.Comentarios);
        //            parametros.Add("@motivoBaja", solicitudFiniquito.MotivoBaja);
        //            parametros.Add("@express", solicitudFiniquito.Express);
        //            parametros.Add("@registroId", solicitudFiniquito.registroId);
        //            parametros.Add("@vacacionesPendientes", solicitudFiniquito.vacacionesPendientes);
        //            parametros.Add("@vacacionesSolicitadas", solicitudFiniquito.vacacionesSolicitadas);
        //            parametros.Add("@periodo", solicitudFiniquito.periodoDeVacaciones);
        //            parametros.Add("@estatusSolicitud", solicitudFiniquito.estatusSolicitud);
        //            parametros.Add("@Comisiones", solicitudFiniquito.Comisiones);
        //            parametros.Add("@DeudaEmpleado", solicitudFiniquito.DeudaEmpleado);
        //            parametros.Add("@solicitudFiniquitoId", DbType.Int32, direction: ParameterDirection.Output);
        //            db.Execute("nasp_SolicitudFiniquito_InsertUpdate", parametros, commandType: CommandType.StoredProcedure);
        //            Respuesta = parametros.Get<int>("@solicitudFiniquitoId");
        //        }
        //    });

        //    return Respuesta;
        //}



    }

}

