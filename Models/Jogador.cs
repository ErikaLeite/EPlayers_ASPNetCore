namespace EPlayers_ASPNetCore.Models
{
    public class Jogador
    {
        public int IdJogador { get; set; }
        public string NomeJogador { get; set; }
        public int IdEquipe { get; set; }       
        private const string PATH = "Database/Jogador.csv";
    }
}