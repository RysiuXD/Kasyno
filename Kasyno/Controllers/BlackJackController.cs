﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kasyno.Classes;

namespace Kasyno.Controllers
{
    public class BlackJackController : Controller
    {
       static  BlackJackGame BlackJackGame = new BlackJackGame();
        public IActionResult Index()
        {
            BlackJackGame.Rozdanie();
            BlackJackGame.LiczPunkty();
          //  BlackJackGame.GameOutcome();
          return View("BlackJackGame", BlackJackGame);
        }

        public IActionResult Hit()
        {
            BlackJackGame.PlayerHit();
            return View("BlackJackGame", BlackJackGame);
        }


    }
}
