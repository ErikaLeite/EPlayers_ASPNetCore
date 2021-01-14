using System;
using EPlayers_ASPNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_ASPNetCore.Controllers
{
    // O controlador irá acessar as informações necessárias através do Route - linkando a classe de Model e View
    [Route("Equipe")]
    //http://localhost5000/Equipe


    public class EquipeController : Controller //é necessário herdar para que as funcionalidades sejam acessíveis - comunicação com frontend
    {
        Equipe equipeModel = new Equipe();

        //Precisamos dferenciar as rotas das Actions, para que não haja conflitos de navegação
        [Route("Listar")]

        public IActionResult Index()
        //enviaremos as informações contidas no objeto instaciado para a View através deste método
        {
            //Listamos as equipes e as enviamos para a View, através da ViewBag
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        //Precisamos dferenciar as rotas das Actions, para que não haja conflitos de navegação
        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();

            //Criaremos, posteriormente, um formulário que irá coletar as informações colocadas neste método, associando-os à instância de uma novo objeto Equipe (novaEquipe)
            novaEquipe.IdEquipe   = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome       = form["Nome"];
            novaEquipe.Imagem     = form["Imagem"];

            //Ao chegar neste momento do código, as informações serão enviadas ao Método Create na classe Equipe que serve para inseri-las nas linhas do arquivo CSV
            equipeModel.Create(novaEquipe);
            ViewBag.Equipes = equipeModel.ReadAll();//novamente, enviaremos as informações para a View

            //Método utilizado para redirecionamento para a page escolhida. Neste caso, manteremos na page Equipe
            return LocalRedirect("~/Equipe/Listar"); 
        }
    }
}