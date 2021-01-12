using System.Collections.Generic;
using System.IO;
using EPlayers_ASPNetCore.Interfaces;

namespace EPlayers_ASPNetCore.Models
{
    public class Equipe : EplayersBase , IEquipe
    //Primeito herda-se a Superclasse e em seguida (separado por ' , ') a Interface
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        //Implementaremos nosso PATH (pasta raiz em que serão criados os arquivos csv)
        private const string PATH = "Database/Equipe.csv";



        //Criamos um método construtor para utilizarmos o Método Create da Super Classe
        public Equipe()
        {
            //inserindo nossa constante PATH como argumento
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Equipe eLinha)
        //Método para criar a estrutura de linha do CSV
        {
            return $"{eLinha.IdEquipe};{eLinha.Nome};{eLinha.Imagem}";
        }


        //Métodos importados da Interface IEquipe
        public void Create(Equipe equipeCriar)
        {
            //string de array necesário como argumento para a criação das linhas no arquivo CSV, incluindo o Construtor Preapare que já padronizou os atributos das linhas
            string [] linhas = {Prepare(equipeCriar)};
            //Meio para criar novas linhas
            File.AppendAllLines(PATH,linhas);
        }

        public void Delete(int idDeletar)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            //Removeremos a linha
            //Faremos uma comparação entre o ID que se deseja excluir e o da equipe cadastrada, para isso EXPRESSÃO LAMBDA
            //COMPARAÇÃO: verificar se X no índice 0 é == ao IDEQUIPE (que foi convertido para string com ToString) e à partir daí fazer a exclusão
            linhas.RemoveAll(x => x.Split(";")[0] == idDeletar.ToString());

            //Ao realizar tais alterações, o arquivo não foi reescrito, para isso utilizamos o método da super classe ReWrite
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            //Meio para fazer a leitura e inserçãode itens na Lista
            //Leitura:
            string[] linhas = File.ReadAllLines(PATH);

            //Configurar linhas para inserir na Lista
            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Equipe novaEquipe   = new Equipe();

                novaEquipe.IdEquipe = int.Parse (linha[0]);
                novaEquipe.Nome     = linha [1];
                novaEquipe.Imagem   = linha [2];

                //Após leitura e configuração, inserimos os dados na lista
                equipes.Add(novaEquipe);
            }

            return equipes;            
        }

        public void Update(Equipe equipeAlterar)
        {
            //Leremos todas as linhas do CSV
            List<string> linhas = ReadAllLinesCSV(PATH);

            //Removeremos a linha que precisar ser alterada
            //Faremos uma comparação entre o ID que se deseja alterar e o da equipe cadastrada, para isso EXPRESSÃO LAMBDA
            //COMPARAÇÃO: verificar se X no índice 0 é == ao IDEQUIPE (que foi convertido para string com ToString) e à partir daí fazer a exclusão
            linhas.RemoveAll(x => x.Split(";")[0] == equipeAlterar.IdEquipe.ToString());

            //Inserimos ao final do CSV a linha com os dados alterados
            //Utilizamos o método Prepare que padroniza a linha como precisamos que ela seja (como argumento inserimos a equipe com os dados alterados)
            linhas.Add(Prepare(equipeAlterar));

            //Ao realizar tais alterações, o arquivo não foi reescrito, para isso utilizamos o método da super classe ReWrite
            RewriteCSV(PATH, linhas);

        }
    }
}