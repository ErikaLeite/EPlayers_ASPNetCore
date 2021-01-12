namespace EPlayers_ASPNetCore.Models
{
    public class Noticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/Noticia.csv";
    }
}