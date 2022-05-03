using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kasyno.Classes;

namespace Kasyno.Controllers
{
    public class BlackJackController : Controller
    {
         BlackJackGame BlackJackGame = new BlackJackGame();
        public IActionResult Index()
        {
            BlackJackGame.Rozdanie();
          return View("BlackJackGame", BlackJackGame);
        }

        


    }
}
