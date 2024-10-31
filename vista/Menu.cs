using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
