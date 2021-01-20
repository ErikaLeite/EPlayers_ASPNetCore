using System.Collections.Generic;
using EPlayers_ASPNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_ASPNetCore.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]//espécie de cookie
        public string Mensagem { get; set; }
        Jogador jogadorModel = new Jogador();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            // Lemos todos os arquivos do CSV
            List<string> csv = jogadorModel.ReadAllLinesCSV(jogadorModel.PATH);

            // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(x =>       x.Split(";")[2] == form["Email"]        &&      x.Split(";")[3] == form["Senha"]);

            // Redirecionamos o usuário logado caso encontrado
            if(logado != null)
            {
                //criamos uma sessão com os dados do user
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);//Posição 1 referente ao nome do user cadastrado ---> NPODE SER O NICKNAME (PROJETO INSTADEV) <---
                return LocalRedirect("~/");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}