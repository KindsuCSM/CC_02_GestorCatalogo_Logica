using _02_CristinaSanchez_GestorCatalogo.controlador;
using _02_CristinaSanchez_GestorCatalogo.modelo;
using _02_CristinaSanchez_GestorCatalogo.vista;

namespace _02_CristinaSanchez_GestorCatalogo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Artista> lstArtista = new List<Artista>();
            lstArtista = CtrlCatalogo.leerArchivo();
            
            CtrlArtista.mostrarLista(lstArtista);
            
            Menu mn = new Menu(lstArtista);

        }
    }
}
