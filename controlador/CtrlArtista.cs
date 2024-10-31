using _02_CristinaSanchez_GestorCatalogo.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _02_CristinaSanchez_GestorCatalogo.controlador
{
    internal static class CtrlArtista
    {
        public static List<Artista> artistas = new List<Artista>();
        static CtrlArtista()
        {
            artistas = inicializarLista();
        }
        private static List<Artista> inicializarLista()
        {
            GeneroMusical genero;
                //Crear las instancias de las clases bandas y solistas
                // Bandas
                ArtistaBanda coldplay = new ArtistaBanda("Chris Martin,Jonny Buckland,Guy Berryman,Will Champion,Phil Harvey", 5, "Coldplay", 1997, "Warner Music", 9, GeneroMusical.PopRock, true);
                ArtistaBanda bringMeTheHorizon = new ArtistaBanda("Oliver Sykes,Lee Malia,Matt Kean,Matt Nicholls,Jordan Fish", 5, "Bring Me The Horizon", 2004, "RCA Records", 6, GeneroMusical.Metal, true);
                ArtistaBanda systemOfADown = new ArtistaBanda("Serj Tankian,Daron Malakian,Shavo Odadjian,John Dolmayan", 4, "System Of A Down", 1994, "Columbia Records", 5, GeneroMusical.Metal, true);
                ArtistaBanda linkinPark = new ArtistaBanda("Mike Shinoda,Brad Delson,Dave Farrell,Rob Bourdon,Joe Hahn,Chester Bennington", 6, "Linkin Park", 1996, "Warner Bros. Records", 7, GeneroMusical.Rock, false);
                ArtistaBanda theJackson5 = new ArtistaBanda("Jackie Jackson,Tito Jackson,Jermaine Jackson,Marlon Jackson,Michael Jackson", 5, "The Jackson 5", 1964, "Motown Records", 13, GeneroMusical.Pop, false);

                // Solistas
                ArtistaSolista tupac = new ArtistaSolista("Tupac Amaru Shakur", "Vocal", "Tupac", 1987, "Death Row Records", 11, GeneroMusical.Rap, false);
                ArtistaSolista kendrickLamar = new ArtistaSolista("Kendrick Lamar Duckworth", "Vocal", "Kendrick Lamar", 2004, "Top Dawg Entertainment", 5, GeneroMusical.HipHop, true);
                ArtistaSolista iceCube = new ArtistaSolista("O'Shea Jackson", "Vocal", "Ice Cube", 1986, "Priority Records", 10, GeneroMusical.Rap, true);
                ArtistaSolista delaossa = new ArtistaSolista("Daniel Martínez de la Ossa Romero", "Vocal", "Delaossa", 2017, "Space Hammu", 3, GeneroMusical.Urbano, true);
                ArtistaSolista yendry = new ArtistaSolista("Yendry Cony Fiorentino", "Vocal", "Yendry", 2012, "Sony Music", 0, GeneroMusical.Urbano, true);
                
                artistas.Add(coldplay);
                artistas.Add(bringMeTheHorizon);
                artistas.Add(systemOfADown);
                artistas.Add(linkinPark);
                artistas.Add(theJackson5);
                artistas.Add(tupac);
                artistas.Add(kendrickLamar);
                artistas.Add(iceCube);
                artistas.Add(delaossa);
                artistas.Add(yendry);

                return artistas; 
        }
        public static void addArtistaSolista(ArtistaSolista artista)
        {
            artistas.Append(artista);
        }
        
        public static void addArtistaBanda(ArtistaBanda artista)
        {
            artistas.Append(artista);
        }

        public static void removeArtista(Artista artista)
        {
            
        }

        public static void orderLista()
        {
            foreach (Artista artista in artistas)
            {
                Console.WriteLine(artista.ToString());
            }
        }

        public static void searchArtista()
        {
            
        }
    }
}
