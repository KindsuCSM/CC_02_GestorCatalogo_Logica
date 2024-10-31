using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_CristinaSanchez_GestorCatalogo.modelo;
using _02_CristinaSanchez_GestorCatalogo.controlador;

namespace _02_CristinaSanchez_GestorCatalogo.vista
{
    internal class Menu
    {
        public Menu()
        {
            MenuPrincipal();
        }
        public static void MenuPrincipal()
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
                            darAlta();
                            break;
                        case 2:
                            buscarElemento();
                            break;
                        case 3:
                            eliminarElemnto();
                            break;
                        case 4:
                            listarArtistas();
                            break;
                        default: 
                            Console.WriteLine("El numero que ha introducido no es válido.");
                            break;
                    }
                }
            } while (continuar);
        }

        private static void darAlta()
        {
            Console.WriteLine("1 - Solista");
            Console.WriteLine("2 - Banda");
            Console.Write("Ingrese la opción que desea:");
            int opcion = Int32.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ArtistaSolista solista = introducirDatosSolista();
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

        //Funciona
        private static ArtistaSolista introducirDatosSolista()
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
            Console.WriteLine("Introduzca los nombres de los integrantes: ");
            String lstmiembros = Console.ReadLine();
            Console.WriteLine("Numero de integrantes:");
            int numIntegrantes = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nombre artistico:");
            String nombreArtistico = Console.ReadLine();
            Console.WriteLine("Año de incicios:");
            int anioInicio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Discografía:");
            String disgrafico = Console.ReadLine();
            Console.WriteLine("Numero de discos:");
            int numDiscos = Int32.Parse(Console.ReadLine());
            Console.WriteLine("¿Se encuentra activo?(Si-No)");
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
            Console.Write("Introduzca el genero (0-11)");
            int genero = Int32.Parse(Console.ReadLine()) - 1;
            
            //Hacer un cast del número introducido al valor del enum
            GeneroMusical generoMusical = (GeneroMusical) genero;
            
            //Retornar un nuevo ArtistaBanda
            return new ArtistaBanda(lstmiembros, numIntegrantes, nombreArtistico, anioInicio, disgrafico, numDiscos, generoMusical ,estaActivo);
        }
        
        private static void buscarElemento()
        {
            
            
            
        }
        
        //No funciona
        private static void eliminarElemnto()
        {
            
        }
        //Funciona a medias xd no actualiza lista
        private static void listarArtistas()
        {
            CtrlArtista.orderLista();
        }
    }
}
