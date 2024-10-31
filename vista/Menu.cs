using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_CristinaSanchez_GestorCatalogo.modelo;

namespace _02_CristinaSanchez_GestorCatalogo.vista
{
    internal class Menu
    {
        public void MenuPrincipal()
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
                int opcion = Int32.Parse(Console.ReadLine());

                if (opcion == 0)
                {
                    continuar = false;
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
                            listarElemento();
                            break;
                        default: 
                            Console.WriteLine("El numero que ha introducido no es válido.");
                            break;
                    }
                }
            } while (continuar == true);
        }

        private void darAlta()
        {
            Console.WriteLine("1 - Solista");
            Console.WriteLine("2 - Banda");
            int opcion = Int32.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ArtistaSolista solista = introducirDatosSolista();
                    break;
                case 2:
                    ArtistaBanda banda = introducirDatosBanda();
                    break;
                default:
                    break;
            }


        }

        private ArtistaSolista introducirDatosSolista()
        {
            int contador = 0;
            bool estaActivo;
            
            Console.WriteLine("Nombre real:\t");
            String nombre = Console.ReadLine();
            Console.WriteLine("Instrumento:\t");
            String instrumento = Console.ReadLine();
            Console.WriteLine("Nombre artistico:\t");
            String nombreArtistico = Console.ReadLine();
            Console.WriteLine("Año de incicios:\t");
            int anioInicio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Discografía:\t");
            String disgrafico = Console.ReadLine();
            Console.WriteLine("Numero de discos:\t");
            int numDiscos = Int32.Parse(Console.ReadLine());
            Console.WriteLine("¿Se encuentra activo?(Si-No)");
            string active = Console.ReadLine();
            estaActivo = (active == "Si")? true : false;
            Console.WriteLine("Genero musical:");
            foreach (Artista.GeneroMusical genero in Enum.GetValues(typeof(Artista.GeneroMusical)))
            {
                Console.WriteLine($"{contador} - {genero}");
                contador++;
            }
            int genero = Int32.Parse(Console.ReadLine());
            Artista.GeneroMusical generoMusical = (Artista.GeneroMusical)genero;
            
            return new ArtistaSolista(nombre, instrumento, nombreArtistico, anioInicio, disgrafico, numDiscos, generoMusical ,estaActivo);
        }
        
        

        private void buscarElemento()
        {
            
        }

        private void eliminarElemnto()
        {
            
        }

        private void listarElemento()
        {
            
        }
        
        
    }


}
