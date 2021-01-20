using System.Collections.Generic;
using System.IO;

namespace EPlayers_ASPNetCore.Models
{
    public class EplayersBase
    {
    
        public void CreateFolderAndFile(string _path)
        //neste método, definimos a localização e configuramos como a pasta e arquivo csv serão localizados (ou criados) e as suas posições
            {
                //ensinamos ao sistema como separar a pasta dos arquivos CSV, por meio do caminho padrão
                //DataBase/Equipe.csv
                //  [0]  /   [1]
                //Data base = pasta a ser criada e lida como a string folder
                //NomeDaClasse.csv = arquivo a ser criado, e lido como string file
                //O arquivo/file, cujo o nome é o mesmo da classe que utilizar o método (ex.: Equipe.csv / Partida.csv / Noticia.csv) para coletar as informações prestadas
                string folder = _path.Split("/")[0];
                

                //criamos uma condicional para que, caso não exista, a pasta raiz (Database), seja criada 
                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                //assim como os arquivos .csv
                if(!File.Exists(_path))
                {
                    File.Create(_path);
                }

                //Em seguida criamos uma pasta Interfaces para que os métodos CRUD sejam utilizados por suas classes correpondentes
            }

        public List<string> ReadAllLinesCSV(string path)
        //Método para ler todas as linhas do arquivo CSV / abrindo e fechando o arquivo automáticamente
        {
            List<string> linhas = new List<string>();

            using(StreamReader file = new StreamReader(path))
            //responsável por abrir e fechar o arquivo
            //StreamReader = leitor de dados de um arquivo
            {
                string linha;

                //Percorremos as linhas através de um laço while
                while ((linha = file.ReadLine()) != null)
                //definição do while ((enquanto a linha lida) for DIFERENTE de vazia o laço percorre)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        public void RewriteCSV(string _path, List<string> linhas)
        //Método para reescrever o CSV quando alterado.
        {
            using(StreamWriter saida = new StreamWriter(_path))
            //StreamWriter = Escritor de dados de um arquivo
            {
                foreach (var item in linhas)
                {
                    saida.Write(item + '\n');
                }
            }
        }

    }
}