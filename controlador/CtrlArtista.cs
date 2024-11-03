using _02_CristinaSanchez_GestorCatalogo.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            artistas.Add(artista);
        }
        public static void addArtistaBanda(ArtistaBanda artista)
        {
            artistas.Add(artista);
        }
        public static void orderLista(string atributo)
        {
            List<Artista> lista = new List<Artista>();
            switch (atributo)
            {
                case "nombre grupo":
                    artistas.OrderBy(n => n.NombreGrupo).ToList();
                    break;
                case "año inicio":
                    artistas.OrderBy(n => n.AnioInicios).ToList();
                    break;
                case "discografia":
                    artistas.OrderBy(n => n.Discografia).ToList();
                    break;
                case "numero de discos":
                    artistas.OrderBy(n => n.NumDiscos).ToList();
                    break;
                case "genero":
                    artistas.OrderBy(n => n.Genero).ToList();
                    break;
                case "activo":
                    artistas.OrderBy(n => n.EstaActivo).ToList();
                    break;
            }
            mostrarLista(artistas);
        }

        public static void mostrarLista(List<Artista> lista)
        {
            foreach (Artista artista in lista)
            {
                Console.WriteLine(artista);
            }
        }
        public static void searchArtista(Dictionary<string, string> diccionario)
        {
            List<Artista> artistasFiltrados = new List<Artista>();
            bool cumpleRequisitos;
            
            foreach (Artista artista in artistas)
            {
                cumpleRequisitos = true;
                foreach (KeyValuePair<string, string> valor in diccionario)
                {
                    string atributo = valor.Key;
                    string valorAtributo = valor.Value;
                    
                    //Cogemos de entre todos los atributos que tiene el artista
                    PropertyInfo pi = artista.GetType().GetProperty(atributo);
                    object valorPropiedad = pi.GetValue(artista);

                    // Comparar valorPropiedad y valorAtributo como strings
                    if (valorPropiedad == null || valorPropiedad.ToString().ToLower() != valorAtributo)
                    {
                        cumpleRequisitos = false;
                        break;
                    }
                }
                if (cumpleRequisitos)
                {
                    artistasFiltrados.Add(artista);
                }
            }
            if (artistasFiltrados.Count == 1)
            {
                mostrarLista(artistasFiltrados);
                foreach (Artista artista in artistasFiltrados)
                {
                    removeArtista(artista);
                }
            }
            else
            {
                Console.WriteLine($"Se han encontrado {artistasFiltrados.Count} artistas en total.");
                mostrarLista(artistasFiltrados);
            }

        }
        public static void removeArtista(Artista artista)
        {
            Console.Write($"¿Desea borrar el artista {artista.NombreGrupo}?(si - no): ");
            string opc = Console.ReadLine().ToLower();
            if (opc.Equals("si"))
            {
                artistas.Remove(artista);
                Console.WriteLine("El artista se ha eliminado con éxito.");
            }
        }
    }
}
