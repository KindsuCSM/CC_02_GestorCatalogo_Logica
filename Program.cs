using _02_CristinaSanchez_GestorCatalogo.controlador;
using _02_CristinaSanchez_GestorCatalogo.modelo;

namespace _02_CristinaSanchez_GestorCatalogo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bandas
            //Coldplay
            //Bring me the horizon
            //System Of A Down
            //Linkin Park

            //Solistas
            //Tupac
            //Kendrik Lamar
            //Ice cube
            //Delaossa

            ArtistaSolista yendry = new ArtistaSolista("Yendry Cony Fiorentino", "Vocal", "Yendry", 2012, "Sony Music", 0, GeneroMusical.Urbano, true);
            ArtistaBanda coldplay = new ArtistaBanda("Chris Martin,Jonny Buckland,Guy Berryman,Will Champion,Phil Harvey", 5, "Coldplay", 1997, "Warner Music", 9, GeneroMusical.PopRock, true);
            List<Artista> artistas = new List<Artista>();

            artistas.Add(coldplay);
            artistas.Add(yendry);

            foreach (Artista artista in artistas)
            {
                Console.WriteLine(artista.ToString());
            }

        }
    }
}
