using _02_CristinaSanchez_GestorCatalogo.modelo;
using System.Reflection;

namespace _02_CristinaSanchez_GestorCatalogo.controlador
{
    internal class CtrlArtista
    {
        private static List<Artista> artistas;
        public CtrlArtista()
        {
            artistas = CtrlCatalogo.leerArchivo();
        }

        public static List<Artista> getListaArtistas()
        {
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
            List<Artista> lstOrdenada = new List<Artista>();
            switch (atributo)
            {
                case "nombre grupo":
                    lstOrdenada = artistas.OrderBy(n => n.NombreGrupo).ToList();
                    break;
                case "año inicio":
                    lstOrdenada = artistas.OrderBy(n => n.AnioInicios).ToList();
                    break;
                case "discografia":
                    lstOrdenada = artistas.OrderBy(n => n.Discografia).ToList();
                    break;
                case "numero de discos":
                    lstOrdenada = artistas.OrderBy(n => n.NumDiscos).ToList();
                    break;
                case "genero":
                    lstOrdenada = artistas.OrderBy(n => n.Genero).ToList();
                    break;
                case "activo":
                    lstOrdenada = artistas.OrderBy(n => n.EstaActivo).ToList();
                    break;
            }
            mostrarLista(lstOrdenada);
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
