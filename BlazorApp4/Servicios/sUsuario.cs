using BlazorApp4.Datos;
using BlazorApp4.Models;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp4.Servicios
{
    public class sUsuario
    {
        dUsuario accesoDatos;

        public sUsuario(string cnn) 
        { 
            accesoDatos=new dUsuario(cnn);
        }

        public async Task<List<mUsuario>> GetUsuarios()
        {
            try
            {
                return await accesoDatos.GetUsuarios();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<mUsuario>> CreateUsuarios(mUsuario usuario)
        {
            try
            {
                return await accesoDatos.GetUsuarios();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<mUsuario>> UpdateUsuarios(mUsuario usuario)
        {
            try
            {
                return await accesoDatos.GetUsuarios();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<mUsuario>> DeleteUsuarios(mUsuario usuario)
        {
            try
            {
                return await accesoDatos.GetUsuarios();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
