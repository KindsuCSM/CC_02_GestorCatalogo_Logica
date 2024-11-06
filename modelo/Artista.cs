namespace _02_CristinaSanchez_GestorCatalogo.modelo
{    
    internal class Artista
    {
        public const int MAX_STRING_BG = 30;
        public const int MAX_STRING_SM = 10;

        private string nombreGrupo;
        private int anioInicios;
        private string discografia;
        private int numDiscos;
        private string generoMusical;
        private bool estaActivo;

        public Artista(string nombreGrupo, int anioInicios, string discografia, int numDiscos, GeneroMusical genero, bool estaActivo)
        {
            NombreGrupo = nombreGrupo;
            AnioInicios = anioInicios;
            Discografia = discografia;
            NumDiscos = numDiscos;
            Genero = genero;
            EstaActivo = estaActivo;
        }
        public string NombreGrupo
        {
            get { return nombreGrupo; }
            set { nombreGrupo = (value.Length <= MAX_STRING_BG) ? value : value.Substring(0, MAX_STRING_BG); }
        }
        public int AnioInicios { get; set; }
        public int NumDiscos { get; set; }
        public GeneroMusical Genero {  get; set; }
        public string Discografia
        {
            get { return discografia; }
            set { discografia = (value.Length <= MAX_STRING_SM) ? value : value.Substring(0, MAX_STRING_SM); }
        }
        public bool EstaActivo { get; set; }

        public override string ToString()
        {
            string activo =  (EstaActivo) ? "Actualmente se encuentra activo" : "Actualmente no se encuentra activo";
            
            return $"\n\tNombre artístico: {NombreGrupo}\n\tAño comienzo: {AnioInicios}\n\tNúmero de discos: {NumDiscos}\n\tGénero musical: {Genero.ToString()}\n\tDiscografía: {Discografia}\n\t{activo}";
        }

    }
}
