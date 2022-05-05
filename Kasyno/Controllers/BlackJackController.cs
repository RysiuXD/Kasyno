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

        public IActionResult Stay()
        {
            BlackJackGame.PlayerStays();
            return View("BlackJackGame", BlackJackGame);
        }

        public IActionResult DoubleDown()
        {
            BlackJackGame.PlayerDoubleDown();
            return View("BlackJackGame", BlackJackGame);
        }
        public IActionResult Split()
        {
            BlackJackGame.PlayerSplit();
            return View("BlackJackGame", BlackJackGame);
        }

        public IActionResult ChangeHand()
        {
            BlackJackGame.ChangeHand();
            return View("BlackJackGame", BlackJackGame);
        }

        public IActionResult BetRise()
        {
            BlackJackGame.RiseBet();
            return View("BlackJackGame", BlackJackGame);
        }

        public IActionResult BetLower()
        {
            BlackJackGame.LowerBet();
            return View("BlackJackGame", BlackJackGame);
        }

    }
}
