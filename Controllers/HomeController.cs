using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayers_ASPNetCore.Models;
using Microsoft.AspNetCore.Http;

namespace EPlayers_ASPNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("_UserName"); //Linkamos a sessão com a home para aparecer o que setamos no .cshtml
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
