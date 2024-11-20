using _02_CristinaSanchez_GestorCatalogo.modelo;
using _02_CristinaSanchez_GestorCatalogo.controlador;

namespace _02_CristinaSanchez_GestorCatalogo.vista
{
    internal class Menu
    {
        public Menu()
        {
            new CtrlArtista(); //inicializar la lista
            MenuPrincipal();
        }

        /*Función que mostrará al usuario las opciones que puede hacer*/
        private static void MenuPrincipal()
        {
            bool continuar = true;
            do
            {
                Console.WriteLine("MENU DE OPCIONES: ");
                Console.WriteLine("1 - Dar de alta un artista. ");
                Console.WriteLine("2 - Buscar un artista. ");
                Console.WriteLine("3 - Eliminar artistas. ");
                Console.WriteLine("4 - Listar todos los artistas ordenados. ");
                Console.WriteLine("0 - Salir del programa. ");
                Console.Write("Ingrese una opción: ");
                int opcion = Int32.Parse(Console.ReadLine());
                if (opcion == 0)
                {
                    continuar = false;
                    CtrlCatalogo.escribirArchivo(CtrlArtista.getListaArtistas());
                    Console.WriteLine("El programa ha finalizado con éxito. ");
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            DarAlta();
                            break;
                        case 2:
                            BuscarElemento();
                            break;
                        case 3:
                            EliminarElementos();
                            break;
                        case 4:
                            ListarArtistas();
                            break;
                        default:
                            Console.WriteLine("El número que ha introducido no es válido.");
                            break;
                    }
                }
            } while (continuar);
        }

        /*Función para pedir al usuario que tipo de artista quiere introducir y dependiendo de su respuesta
            llamamos a una función del CtrlArtista que introducirá el objeto en la lista */
        private static void DarAlta()
        {
            Console.WriteLine("1 - Solista");
            Console.WriteLine("2 - Banda");
            Console.Write("Ingrese el nombre de la opción que desea: ");
            string opcion = Console.ReadLine().ToLower();
            switch (opcion)
            {
                case "solista":
                    ArtistaSolista solista = IntroducirDatosSolista();
                    CtrlArtista.addArtistaSolista(solista);

                    break;
                case "banda":
                    ArtistaBanda banda = introducirDatosBanda();
                    CtrlArtista.addArtistaBanda(banda);
                    break;
                default:
                    Console.WriteLine("La opción introducida no corresponde a ninguna. ");
                    break;
            }
        }

        private static Artista introducirDatosArtista()
        {
            int contador = 0;
            bool estaActivo;
            Console.Write("Nombre artistíco: ");
            String nombreArtistico = Console.ReadLine();
            Console.Write("Año de inicios: ");
            int anioInicio = Int32.Parse(Console.ReadLine());
            Console.Write("Discografía: ");
            String discografica = Console.ReadLine();
            Console.Write("Número de discos: ");
            int numDiscos = Int32.Parse(Console.ReadLine());
            Console.Write("¿Se encuentra activo?(Si-No): ");
            string active = Console.ReadLine();

            //Convertir el string si o no a booleano
            if (active.ToLower().Equals("si"))
            {
                estaActivo = true;
            }
            else if (active.ToLower().Equals("no"))
            {
                estaActivo = false;
            }
            else
            {
                Console.WriteLine("El valor introducido no es válido. ");
                estaActivo = true;
            }

            Console.WriteLine("Género musical:");
            // Mostrar los valores del enum GeneroMusical
            foreach (GeneroMusical generoArtista in Enum.GetValues(typeof(GeneroMusical)))
            {
                contador++;
                Console.WriteLine($"{contador} - {generoArtista}");
            }

            Console.Write("Introduzca el género (1-12): ");
            int genero = Int32.Parse(Console.ReadLine()) - 1;
            //Hacer un cast del número introducido al valor del enum
            GeneroMusical generoMusical = (GeneroMusical)genero;

            return new Artista(nombreArtistico, anioInicio, discografica, numDiscos, generoMusical, estaActivo);
        }

        //Introducir datos del artista solista
        private static ArtistaSolista IntroducirDatosSolista()
        {
            Console.Write("Nombre real: ");
            String nombre = Console.ReadLine();
            Console.Write("Instrumento: ");
            String instrumento = Console.ReadLine();
            //Obtenemos los datos del padre desde introducirDatosArtista
            Artista art = introducirDatosArtista();
            //Retornar un nuevo ArtistaSolista
            return new ArtistaSolista(nombre, instrumento, art.NombreGrupo, art.AnioInicios, art.Discografia,
                art.NumDiscos, art.Genero, art.EstaActivo);
        }

        //Introducir datos del artista banda
        private static ArtistaBanda introducirDatosBanda()
        {
            Console.Write("Introduzca los nombres de los integrantes: ");
            String lstmiembros = Console.ReadLine();
            Console.Write("Número de integrantes: ");
            int numIntegrantes = Int32.Parse(Console.ReadLine());
            //Obtenemos los datos del padre desde introducirDatosArtista
            Artista art = introducirDatosArtista();

            return new ArtistaBanda(lstmiembros, numIntegrantes, art.NombreGrupo, art.AnioInicios, art.Discografia,
                art.NumDiscos, art.Genero, art.EstaActivo);
        }

        //Función para almacenar en un diccionario los valores por los que desea buscar en la lista
        private static Dictionary<string, string> PedirAtributosBusquedaGenerales()
        {
            var dict = new Dictionary<string, string>();

            string opcion;
            string valor;
            int contadorGeneros = 0;
            int contadorAtributos = 0;
            /*Para no crear tantas estructuras de condicionales, me creo un bucle que recorra una lista con los nombres de atributos
            listos para ser mostrados en la pantalla y creo otra con el mismo orden que la anterior, con los nombres
            de los atributos que voy a introducir en el propio diccionario que luego pasaré a la función de la clase CtrlArtista*/
            string[] atributosArtistaMostrar =
            {
                "nombre del artista", "año de inicio", "discografia", "numero de discos", "genero", "activo"
            };
            string[] atributosArtistaNombres =
            {
                "NombreGrupo", "AnioInicios", "Discografia", "NumDiscos", "Genero", "EstaActivo"
            };

            //Preguntarle por los atributos del padre primero, 
            foreach (string atributo in atributosArtistaMostrar)
            {
                Console.Write($"¿Desea buscar por {atributo}?(Si-No): ");
                opcion = Console.ReadLine().ToLower();
                if (opcion.Equals("si"))
                {
                    //Como hay opciones que requieren de algun cambio a la hora de introducir los datos por consola porque 
                    // sean opciones, los meto en un if y los controlo mejor
                    if (atributo.Equals("genero"))
                    {
                        // Mostrar los generos disponibles del enum
                        Console.WriteLine("Generos disponibles: ");
                        foreach (GeneroMusical generoArtista in Enum.GetValues(typeof(GeneroMusical)))
                        {
                            contadorGeneros++;
                            Console.WriteLine($"{contadorGeneros} - {generoArtista}");
                        }

                        Console.Write($"Introduzca el {atributo}: ");
                        valor = Console.ReadLine().ToLower();
                        dict.Add(atributosArtistaNombres[contadorAtributos], valor);
                    }
                    else if (atributo.Equals("activo"))
                    {
                        Console.Write($"Introduzca {atributo}(Si-No): ");
                        string active = Console.ReadLine().ToLower();

                        valor = (active.Equals("si")) ? "true" : "false";
                        dict.Add(atributosArtistaNombres[contadorAtributos], valor);
                    }
                    else
                    {
                        Console.Write($"Introduzca {atributo}: ");
                        valor = Console.ReadLine().ToLower();
                        dict.Add(atributosArtistaNombres[contadorAtributos], valor);
                    }
                }
                contadorAtributos++;
            }

            foreach (KeyValuePair<string, string> item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            return dict;
        }
        
        /*Función que a partir del diccionario extraído de PedirAtributosBusqueda lo
            pasaremos a una función de CtrlArtista que buscará a los artistas y en caso
            de que sea uno, dar la opción de borrarlo*/
        private static void BuscarElemento()
        {
            CtrlArtista.buscarArtistaYEliminarUno(PedirAtributosBusquedaGenerales());
        }

        /*Función que a partir del diccionario extraído de PedirAtributosBusqueda lo
        pasaremos a una función de CtrlArtista que buscará a los artistas y le dará la opción de borrarlos*/
        private static void EliminarElementos()
        {
            CtrlArtista.deleteArtistas(PedirAtributosBusquedaGenerales());
        }

        /*Función que recogerá la opcion que desea el usuario por la que ordenaremos la lista*/
        private static void ListarArtistas()
        {
            String[] elementos =
                { "nombre grupo", "año inicio", "discografia", "numero de discos", "genero", "activo" };
            int contador = 1;
            string opc;
            bool continuar = true;
            do
            {
                Console.WriteLine("Atributos disponibles: ");
                foreach (string elemento in elementos)
                {
                    Console.WriteLine($"{contador} - {elemento}");
                    contador++;
                }

                Console.WriteLine("¿Por que atributo desea ordenar la lista? Introduzca el nombre: ");
                opc = Console.ReadLine().ToLower();
                if (elementos.Contains(opc))
                {
                    CtrlArtista.orderLista(opc.ToLower());
                    continuar = false;
                }
                else
                {
                    contador = 1;
                    Console.WriteLine("El atributo que ha introducido no se encuentra en la lista. ");
                }
            } while (continuar);
        }
    }
}