using System.Collections.Generic;
using System.IO;
using E_Players_AspNETCore.Interfaces;

namespace EPlayers_ASPNetCore.Models
{
    public class Jogador : EplayersBase, IJogador
    {
        public int IdJogador { get; set; }
        public string NomeJogador { get; set; }
        public int IdEquipe { get; set; }
        public string Email { get; set; }        
        public string Senha { get; set; }        
        public string PATH = "Database/Jogador.csv";
        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }
        public string Prepare(Jogador jLinha)
        //Método para criar a estrutura de linha do CSV
        {
            return $"{jLinha.IdJogador};{jLinha.NomeJogador};{jLinha.Email};{jLinha.Senha}";
        }

        public void Create(Jogador j)
        {
            string[] linha = { Prepare(j) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador jogador     = new Jogador();

                jogador.IdJogador   = int.Parse(linha[0]);
                jogador.NomeJogador = linha[1];
                jogador.Email       = linha[2];
                jogador.Senha       = linha[3];

                jogadores.Add(jogador);
            }
            return jogadores;
        }

        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( Prepare(j) );                        
            RewriteCSV(PATH, linhas); 
        }

        public void Delete(int idJogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            
            linhas.RemoveAll(x => x.Split(";")[0] == idJogador.ToString());                        
            RewriteCSV(PATH, linhas);
        }
    }     
}