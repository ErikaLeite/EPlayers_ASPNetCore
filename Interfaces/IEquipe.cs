using System.Collections.Generic;
using EPlayers_ASPNetCore.Models;

namespace EPlayers_ASPNetCore.Interfaces
{
    public interface IEquipe
    {
        //Nesta interface teremos Métodos CRUD
        void Create (Equipe equipeCriar);
        List<Equipe> ReadAll();
        void Update (Equipe equipeAlterar);
        void Delete (int idDeletar);

        //Tais Métodos serão exportados para a classe Equipe, através de Herança
    }
}