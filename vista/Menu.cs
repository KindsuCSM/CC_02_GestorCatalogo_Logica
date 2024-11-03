using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_CristinaSanchez_GestorCatalogo.modelo;
using _02_CristinaSanchez_GestorCatalogo.controlador;
using Microsoft.VisualBasic.CompilerServices;

namespace _02_CristinaSanchez_GestorCatalogo.vista
{
    internal class Menu
    {
        public Menu()
        {
            MenuPrincipal();
        }
        private static void MenuPrincipal()
        {
            bool continuar = true;
            
            do
            {
                Console.WriteLine("MENU DE OPCIONES: ");
                Console.WriteLine("1 - Dar de alta un elemento. ");
                Console.WriteLine("2 - Buscar un elemento. ");
                Console.WriteLine("3 - Eliminar un elemento. ");
                Console.WriteLine("4 - Listar todos los elementos ordenados. ");
                Console.WriteLine("0 - Salir del programa. ");
                Console.Write("Ingrese una opción: ");
                int opcion = Int32.Parse(Console.ReadLine());
                if (opcion == 0)
                {
                    continuar = false;
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
                            EliminarElemento();
                            break;
                        case 4:
                            ListarArtistas();
                            break;
                        default: 
                            Console.WriteLine("El numero que ha introducido no es válido.");
                            break;
                    }
                }
            } while (continuar);
        }
        private static void DarAlta()
        {
            Console.WriteLine("1 - Solista");
            Console.WriteLine("2 - Banda");
            Console.Write("Ingrese la opción que desea:");
            int opcion = Int32.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    ArtistaSolista solista = IntroducirDatosSolista();
                    CtrlArtista.addArtistaSolista(solista);
                    
                    break;
                case 2:
                    ArtistaBanda banda = introducirDatosBanda();
                    CtrlArtista.addArtistaBanda(banda);
                    break;
                default:
                    Console.WriteLine("La opción introducida no corresponde a ninguna. ");
                    break;
            }
        }
        // Funciones para introducir por consola los datos de los artistas para la funcion darAlta
        private static ArtistaSolista IntroducirDatosSolista()
        {
            int contador = 0;
            bool estaActivo;
            
            //Pedir los datos necesarios para crear una nueva instancia de ArtistaBanda
            Console.Write("Nombre real: ");
            String nombre = Console.ReadLine();
            Console.Write("Instrumento: ");
            String instrumento = Console.ReadLine();
            Console.Write("Nombre artistico: ");
            String nombreArtistico = Console.ReadLine();
            Console.Write("Año de incicios: ");
            int anioInicio = Int32.Parse(Console.ReadLine());
            Console.Write("Discografía: ");
            String disgrafico = Console.ReadLine();
            Console.Write("Numero de discos: ");
            int numDiscos = Int32.Parse(Console.ReadLine());
            Console.Write("¿Se encuentra activo?(Si-No): ");
            string active = Console.ReadLine();
            
            //Convertir el string si o no a booleano
            if (active.ToLower().Equals("si")) { estaActivo = true; }
            else if (active.ToLower().Equals("no")) { estaActivo = false; }
            else { Console.WriteLine("El valor introducido no es válido. "); estaActivo = true; }
            
            Console.WriteLine("Genero musical:");
            // Mostrar los valores del enum GeneroMusical
            foreach (GeneroMusical generoArtista in Enum.GetValues(typeof(GeneroMusical)))
            {
                contador++;
                Console.WriteLine($"{contador} - {generoArtista}");
            }
            Console.Write("Introduzca el genero (0-11)");
            int genero = Int32.Parse(Console.ReadLine()) - 1;
            //Hacer un cast del número introducido al valor del enum
            GeneroMusical generoMusical = (GeneroMusical)genero;
            //Retornar un nuevo ArtistaSolista
            return new ArtistaSolista(nombre, instrumento, nombreArtistico, anioInicio, disgrafico, numDiscos, generoMusical ,estaActivo);
        }
        private static ArtistaBanda introducirDatosBanda()
        {
            int contador = 0;
            bool estaActivo;
            //Pedir los datos necesarios para crear una nueva instancia de ArtistaBanda
            Console.Write("Introduzca los nombres de los integrantes: ");
            String lstmiembros = Console.ReadLine();
            Console.Write("Numero de integrantes: ");
            int numIntegrantes = Int32.Parse(Console.ReadLine());
            Console.Write("Nombre artistico: ");
            String nombreArtistico = Console.ReadLine();
            Console.Write("Año de incicios: ");
            int anioInicio = Int32.Parse(Console.ReadLine());
            Console.Write("Discografía: ");
            String disgrafico = Console.ReadLine();
            Console.Write("Numero de discos: ");
            int numDiscos = Int32.Parse(Console.ReadLine());
            Console.Write("¿Se encuentra activo?(Si-No): ");
            string active = Console.ReadLine();
            //Convertir el string si o no a booleano
            if (active.ToLower().Equals("Si")) { estaActivo = true; }
            else if (active.ToLower().Equals("No")) { estaActivo = false; }
            else { Console.WriteLine("El valor introducido no es válido. "); estaActivo = true; }
            Console.WriteLine("Genero musical:");
            // Mostrar los valores del enum GeneroMusical
            foreach (GeneroMusical generoArtista in Enum.GetValues(typeof(GeneroMusical)))
            {
                contador++;
                Console.WriteLine($"{contador} - {generoArtista}");
            }
            Console.Write("Introduzca el genero (0-11): ");
            int genero = Int32.Parse(Console.ReadLine()) - 1;
            //Hacer un cast del número introducido al valor del enum
            GeneroMusical generoMusical = (GeneroMusical) genero;
            //Retornar un nuevo ArtistaBanda
            return new ArtistaBanda(lstmiembros, numIntegrantes, nombreArtistico, anioInicio, disgrafico, numDiscos, generoMusical ,estaActivo);
        }
        private static Dictionary<string, string> PedirAtributosBusqueda() 
        {
            var dict = new Dictionary<string, string>();
            
            string opcion;
            string valor;
            int contadorGeneros = 0;
            int contadorAtributos = 0;
            /*Para no crear tantas estructuras de condicionales, me creo un bucle que recorra una lista con los nombres de atributos
            //listos para ser mostrados en la pantalla y creo otra con el mismo orden que la anterior, con los nombres
            //de los atributos que voy a introducir en el propio diccionario que luego pasaré a la función de la clase CtrlArtista*/
            string[] atributosArtistaMostrar = [ "nombre del artista", "año de inicio", "discografia", "genero", "activo(Si-No)", "nombre real", "instrumento" ];
            string[] atributosArtistaNombres = [ "NombreGrupo", "AnioInicios", "Discografia", "Genero", "EstaActivo", "NombreReal", "InstrumentoPrincipal" ];
            
            //Preguntarle por los atributos del padre primero, 
            foreach (string atributo in atributosArtistaMostrar)
            {
                Console.Write($"¿Desea buscar por {atributo}?(Si-No): ");
                opcion = Console.ReadLine().ToLower();
                if (opcion.Equals("si"))
                {
                    if (atributo.Equals("Genero"))
                    {
                        Console.Write($"Introduzca {atributo}: ");
                        foreach (GeneroMusical generoArtista in Enum.GetValues(typeof(GeneroMusical)))
                        {
                            contadorGeneros++;
                            Console.WriteLine($"{contadorGeneros} - {generoArtista}");
                        }
                        Console.Write($"Introduzca el {atributo}: ");
                        valor = Console.ReadLine();
                        dict.Add("Genero", valor);
                    }
                    else
                    {
                        Console.Write($"Introduzca {atributo}: ");
                        valor = Console.ReadLine();
                        dict.Add(atributosArtistaNombres[contadorAtributos], valor);
                    }
                }
                contadorAtributos++;
            }
            
            /*En caso de que el diccionario no tenga ninguno de los atributos del artista solitario, entrará a preguntar 
            si quiere buscar por los atributos del artista banda*/
            if (!dict.ContainsKey("NombreReal") && !dict.ContainsKey("InstrumentoPrincipal"))
            {
                Console.Write($"¿Desea buscar por un miembro del grupo?(Si-No): ");
                opcion = Console.ReadLine().ToLower();
                if (opcion.Equals("si"))
                {
                    Console.Write("Introduzca el nombre del miembro: ");
                    valor = Console.ReadLine();
                    dict.Add("LstMiembros", valor);
                }
                Console.Write("Desea buscar por el numero de miembros?(Si-No):");
                opcion = Console.ReadLine().ToLower();
                if (opcion.Equals("si"))
                {
                    Console.Write("Introduzca el numero de miembros: ");
                    valor = Console.ReadLine();
                    dict.Add("NumMiembros", valor);
                }
            }
            return dict;
        }
        private static void BuscarElemento()
        {
            CtrlArtista.searchArtista(PedirAtributosBusqueda());
        }
        private static void EliminarElemento()
        {
            CtrlArtista.removeArtista(PedirAtributosBusqueda());
        }
        private static void ListarArtistas()
        {
            CtrlArtista.orderLista();
        }
    }
}