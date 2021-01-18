namespace EPlayers_ASPNetCore.Models
{
    public class Jogador : EplayersBase
    {
        public int IdJogador { get; set; }
        public string NomeJogador { get; set; }
        public int IdEquipe { get; set; }
        public string Email { get; set; }        
        public string Senha { get; set; }        
        private const string PATH = "Database/Jogador.csv";
    }       
    
}