using _02_CristinaSanchez_GestorCatalogo.modelo;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

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

        public static void deleteArtistas(Dictionary<string, string> dicArtistas)
        {
            String opcion = "";
            List<Artista> lstArtistasEncontrados = searchArtista(dicArtistas);
            mostrarLista(lstArtistasEncontrados);

            for (int i = 0; i < lstArtistasEncontrados.Count; i++)
            {
                Console.WriteLine($"Desea eliminar el artista {(i + 1)}");
                opcion = Console.ReadLine().ToLower();
                if (opcion == "si")
                {
                    artistas.Remove(lstArtistasEncontrados[i]);
                }
            }
        }

        public static void buscarArtistaYEliminarUno(Dictionary<string, string> dicArtistas)
        {
            List<Artista> lstArtistasEncontrados = searchArtista(dicArtistas);

            mostrarLista(lstArtistasEncontrados);

            if (lstArtistasEncontrados.Count == 1)
            {
                Console.WriteLine("¿Desea eliminar el artista encontrado?(Si-No)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta == "si")
                {
                    artistas.Remove(lstArtistasEncontrados[0]);
                }
            }
        }

        public static List<Artista> searchArtista(Dictionary<string, string> diccionario)
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
                    if (atributo.Equals("NombreGrupo"))
                    {
                        if (!artista.NombreGrupo.ToLower().Equals(valorAtributo))
                        {
                            cumpleRequisitos = false;
                            break;
                        }
                    }

                    if (atributo.Equals("AnioInicios"))
                    {
                        if (!artista.AnioInicios.Equals(Int32.Parse(valorAtributo)))
                        {
                            cumpleRequisitos = false;
                            break;
                        }
                    }

                    if (atributo.Equals("Discografia"))
                    {
                        if (!artista.Discografia.ToLower().Equals(valorAtributo))
                        {
                            cumpleRequisitos = false;
                            break;
                        }
                    }

                    if (atributo.Equals("NumDiscos"))
                    {
                        if (!artista.NumDiscos.Equals(Int32.Parse(valorAtributo)))
                        {
                            cumpleRequisitos = false;
                            break;
                        }
                    }

                    if (atributo.Equals("Genero"))
                    {
                        if (!artista.Genero.ToString().Equals(valorAtributo))
                        {
                            cumpleRequisitos = false;
                            break;
                        }
                    }

                    if (atributo.Equals("EstaActivo"))
                    {
                        if (!artista.EstaActivo.ToString().Equals(valorAtributo))
                        {
                            cumpleRequisitos = false;
                            break;
                        }
                    }

                    if (artista is ArtistaBanda)
                    {
                        ArtistaBanda aux = (ArtistaBanda)artista;
                        if (atributo.Equals("LstMiembros"))
                        {
                            if (!aux.LstMiembros.ToLower().Contains(valorAtributo))
                            {
                                cumpleRequisitos = false;
                                break;
                            }
                        }

                        if (atributo.Equals("NumIntegrantes"))
                        {
                            if (!aux.NumIntegrantes.Equals(Int32.Parse(valorAtributo)))
                            {
                                cumpleRequisitos = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        ArtistaSolista aux = (ArtistaSolista)artista;
                        if (atributo.Equals("NombreReal"))
                        {
                            if (!aux.NombreReal.ToLower().Equals(valorAtributo))
                            {
                                cumpleRequisitos = false;
                                break;
                            }
                        }

                        if (atributo.Equals("InstrumentoPrincipal"))
                        {
                            if (!aux.InstrumentoPrincipal.ToLower().Equals(valorAtributo))
                            {
                                cumpleRequisitos = false;
                                break;
                            }
                        }
                    }
                }

                if (cumpleRequisitos)
                {
                    artistasFiltrados.Add(artista);
                }
            }

            return artistasFiltrados;
        }
    }
}