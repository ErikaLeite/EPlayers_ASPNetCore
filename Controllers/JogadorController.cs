using System;
using System.IO;
using EPlayers_ASPNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_ASPNetCore.Controllers
{
    [Route ("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador     = new Jogador();
            novoJogador.IdJogador   = Int32.Parse(form["idJogador"]);
            novoJogador.NomeJogador = form["Nome"];
            novoJogador.Email       = form["Email"];
            novoJogador.Senha       = form["Senha"];

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();

            return LocalRedirect("~/Jogador/Listar");
        }

    }
}