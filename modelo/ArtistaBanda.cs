using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CristinaSanchez_GestorCatalogo.modelo
{
    internal class ArtistaBanda : Artista
    {
        public const int MAX_STRING = 100;

        private string lstMiembros;
        private int numIntegrantes;
        
        public ArtistaBanda(string lstMiembros, int numIntegrantes, string nombre, 
            int anioInicios, string discografia, int numDiscos, GeneroMusical genero, bool estaActivo) :
            base(nombre, anioInicios, discografia, numDiscos, genero, estaActivo)
        {
            LstMiembros = lstMiembros;
            NumIntegrantes = numIntegrantes;
        }

        public string LstMiembros
        {
            get { return lstMiembros; }
            set { lstMiembros = (value.Length <= MAX_STRING) ? value : value.Substring(0, MAX_STRING); }
        }
        public int NumIntegrantes { get; set; }

        public override string ToString()
        {
            string[] miembros = LstMiembros.Split(',');
            string cadenaCompleta = "";

            foreach (string miembro in miembros)
            {
                cadenaCompleta += $"\n\t\t - {miembro}";
            }
            return $"Banda: \n\tIntegrantes de la banda: {cadenaCompleta}\n\tNumero de integrantes: {NumIntegrantes}" + base.ToString();
        }
    }
}
