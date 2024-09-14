using BlazorApp4.Datos;
using BlazorApp4.Models;

namespace BlazorApp4.Servicios
{
    public class sAnime
    {
        dAnime accesoDatos;

        public sAnime(string cnn)
        {
            accesoDatos = new dAnime(cnn);
        }
        public async Task<List<mAnime>> GetAnimes()
        {
            try
            {
                return await accesoDatos.GetAnimes();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
