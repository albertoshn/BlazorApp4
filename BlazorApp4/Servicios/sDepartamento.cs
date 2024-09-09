using BlazorApp4.Datos;
using BlazorApp4.Models;

namespace BlazorApp4.Servicios
{
    public class sDepartamento
    {
        dDepartamento accesoDatos;

        public sDepartamento(string cnn) {
            accesoDatos = new dDepartamento(cnn);
        }
        public async Task<List<mDepartamento>> GetDepartamentos() 
        {
            try
            {
                return await accesoDatos.GetDepartamentos();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<mResponse> CreateDepartamento(mDepartamento departamento)
        {
            try
            {
                return await accesoDatos.CreateDepartamento(departamento);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<mResponse> UpdateDepartamento(mDepartamento departamento)
        {
            try
            {
                return await accesoDatos.UpdateDepartamento(departamento);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<mResponse> DeleteDepartamento(mDepartamento departamento)
        {
            try
            {
                return await accesoDatos.DeleteDepartamento(departamento);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        

        //public string getHola() {
        //    return "Hola";
        //}
    }
}
