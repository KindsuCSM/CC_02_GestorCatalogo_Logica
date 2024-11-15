using _02_CristinaSanchez_GestorCatalogo.modelo;

namespace _02_CristinaSanchez_GestorCatalogo.controlador
{
    internal static class CtrlCatalogo
    {
        //Crear constantes
        //El formato que tiene nombre de archivo es para que se nos cree en la carpeta del propio archivo y no en net8.0
        private const string NOMBRE_ARCHIVO = "catalogo.dat"; 
        private const char MARCA_SOLITARIO = 'S';
        private const char MARCA_BANDA = 'B';
        private const int PESO_BYTES_BANDA = 161;
        private const int PESO_BYTES_SOLITARIO = 108;
        
        private static string CompletarCadena(this string str, int size)
        {
            return str.PadRight(size, ' '); //PadRight rellena los huecos a su derecha
        }

        private static bool ContinuarLeyendo(this BinaryReader br, int numBytes)
        {
            bool continuar = false;
            if (br != null)
            {
                continuar = br.BaseStream.Length - br.BaseStream.Position >= numBytes;
            }
            return continuar;
        }

        private static void EscribirArtista(Artista art, BinaryWriter buffOut)
        {
            buffOut.Write(art.NombreGrupo.CompletarCadena(Artista.MAX_STRING_BG));
            buffOut.Write(art.AnioInicios);
            buffOut.Write(art.Discografia.CompletarCadena(Artista.MAX_STRING_SM));
            buffOut.Write(art.NumDiscos);
            buffOut.Write((int)art.Genero);
            buffOut.Write(art.EstaActivo);
        }

        private static void EscribirArtistaBandaSolitario(Artista art, BinaryWriter buffOut)
        {
            if (art is ArtistaBanda)
            {
                ArtistaBanda banda = (ArtistaBanda)art;
                buffOut.Write(MARCA_BANDA);
                buffOut.Write(banda.LstMiembros.CompletarCadena(ArtistaBanda.MAX_STRING));
                buffOut.Write(banda.NumIntegrantes);
                EscribirArtista(banda, buffOut);
            }
            else if (art is ArtistaSolista)
            {
                ArtistaSolista artista = (ArtistaSolista)art;
                buffOut.Write(MARCA_SOLITARIO);
                buffOut.Write(artista.NombreReal.CompletarCadena(ArtistaSolista.MAX_STRING_BG));
                buffOut.Write(artista.InstrumentoPrincipal.CompletarCadena(ArtistaSolista.MAX_STRING_SM));
                EscribirArtista(artista, buffOut);


            }
        }

        private static ArtistaBanda LeerArtistaBanda(BinaryReader buffIn)
        {
            string lstMiembros = buffIn.ReadString().Trim();
            int numIntegrantes = buffIn.ReadInt32();
            string nombreGrupo = buffIn.ReadString().Trim();
            int anioInicios = buffIn.ReadInt32();
            string discografia = buffIn.ReadString().Trim();
            int numDiscos = buffIn.ReadInt32();
            GeneroMusical genero = (GeneroMusical)(buffIn.ReadInt32());
            bool estaActivo = buffIn.ReadBoolean();

            return new ArtistaBanda(lstMiembros, numIntegrantes, nombreGrupo, anioInicios, discografia, numDiscos, genero, estaActivo);
        }

        private static ArtistaSolista LeerArtistaSolista(BinaryReader buffIn)
        {
            string nombreReal = buffIn.ReadString().Trim();
            string instrumentoPrincipal = buffIn.ReadString().Trim();
            string nombreGrupo = buffIn.ReadString().Trim();
            int anioInicios = buffIn.ReadInt32();
            string discografia = buffIn.ReadString().Trim();
            int numDiscos = buffIn.ReadInt32();
            GeneroMusical genero = (GeneroMusical)(buffIn.ReadInt32());
            bool estaActivo = buffIn.ReadBoolean();

            return new ArtistaSolista(nombreReal, instrumentoPrincipal, nombreGrupo, anioInicios, discografia, numDiscos, genero, estaActivo);
        }

        public static List<Artista> leerArchivo()
        {
            string file = "catalogo.dat";
            var list = new List<Artista>();

            if (File.Exists(file))
            {
                try
                {
                    using (var fileArtistas = new FileStream(file, FileMode.Open))
                    {
                        using (BinaryReader buffIn = new BinaryReader(fileArtistas))
                        {
                            while (fileArtistas.Position < fileArtistas.Length - sizeof(char))
                            {
                                char marca = buffIn.ReadChar();
                                switch (marca)
                                {
                                    case MARCA_BANDA:
                                        if (buffIn.ContinuarLeyendo(PESO_BYTES_BANDA - sizeof(char)))
                                        {
                                            list.Add(LeerArtistaBanda(buffIn));
                                        }
                                        break;
                                    case MARCA_SOLITARIO:
                                        if (buffIn.ContinuarLeyendo(PESO_BYTES_SOLITARIO - sizeof(char)))
                                        {
                                            list.Add(LeerArtistaSolista(buffIn));
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al leer del archivo. ERROR: {ex.ToString()}");
                }
            }
            return list;
        }

        public static void escribirArchivo(List<Artista> list)
        {
            int contador = 0;
            if (File.Exists(NOMBRE_ARCHIVO))
            {
                DateTime dateTime = DateTime.Now;
                File.Move(NOMBRE_ARCHIVO, $"{NOMBRE_ARCHIVO.Substring(0, 8)}_{dateTime.Day}-{dateTime.Month}-{dateTime.Year}__{dateTime.Hour}-{dateTime.Minute}-{dateTime.Second}.dat");
            }
            try
            {
                using (var fileStr = new FileStream(NOMBRE_ARCHIVO, FileMode.Create))
                {
                    using (var buffOut = new BinaryWriter(fileStr))
                    {
                        foreach (var artista in list)
                        {
                            EscribirArtistaBandaSolitario(artista, buffOut);
                            contador++;
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir el archivo, se han introducido {contador}. ERROR: {ex.ToString()}");
            }
        }
    }
}
