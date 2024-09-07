using BlazorApp4.Datos;

namespace BlazorApp4.Servicios
{
    public class sUsuario
    {
        dUsuario accesoDatos;

        public sUsuario(string cnn) 
        { 
            accesoDatos=new dUsuario(cnn);
        }
    }
}
