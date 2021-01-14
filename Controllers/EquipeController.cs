using System;
using System.IO;
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
            
            //Inicio Upload
            if (form.Files.Count > 0)
            {
                //recebemos o arquivo enviado pelo usuário e armazenamos na variavel file
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/Equipes");

                //verificamos se a pasta já existe e se não, a criamos 
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                                        //localhost:5001 envia para       wwwroor/img/   Equipes/ foto.jpg
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                //salvaremos as informações
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                //salvar no CSV
                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrao.png";
            }
            //Término


            //Ao chegar neste momento do código, as informações serão enviadas ao Método Create na classe Equipe que serve para inseri-las nas linhas do arquivo CSV
            equipeModel.Create(novaEquipe);
            ViewBag.Equipes = equipeModel.ReadAll();//novamente, enviaremos as informações para a View

            //Método utilizado para redirecionamento para a page escolhida. Neste caso, manteremos na page Equipe
            return LocalRedirect("~/Equipe/Listar"); 
        }
    }
}