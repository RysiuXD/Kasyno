using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasyno.Classes
{
    public class BlackJackGame
    {
        public List<Karta> PlayerHand, DealerHand;
        public Talia Talia;
        public int PunktyGracz, PunktyDealera, Zetony, BetSize;
        public string Komunikat;
        public bool GameOver, FirstAction;

        public BlackJackGame() 
        {
            Komunikat = "Dealer dobiera do 16.";
            PlayerHand = new List<Karta>();
            DealerHand = new List<Karta>();
            Talia = new Talia();
            Talia.Tasuj();
            GameOver = false;
            FirstAction = true;
            Zetony = 200;
            BetSize = 10;
        }
        
        public void PlayerDodajKarte()
        {
            Karta holder = Talia.Karty.First();
            Talia.Karty.Remove(holder);
            PlayerHand.Add(holder);
        }
        public void DealerDodajKarte()
        {
            Karta holder = Talia.Karty.First();
            Talia.Karty.Remove(holder);
            DealerHand.Add(holder);
        }

        public void Rozdanie()
        {
            Komunikat = "Dealer dobiera do 16";
            GameOver = false;
            FirstAction = true;
            BetSize = 10;
            ZbierzKarty();
            DealerDodajKarte();
            DealerDodajKarte();
            PlayerDodajKarte();
            PlayerDodajKarte();
            LiczPunkty();
            BlackJackCheck();
        }


        public void ZbierzKarty()
        {
            foreach (Karta karta in PlayerHand)
            {
                Talia.Karty.Add(karta);
            }
            PlayerHand.Clear();
            foreach (Karta karta in DealerHand)
            {
                Talia.Karty.Add(karta);
            }
            DealerHand.Clear();
        }

        public void LiczPunkty() 
        {
            PunktyGracz = 0;
            foreach (Karta karta in PlayerHand.Where(x => x.Wartosc != 1))
            {

                if (karta.Wartosc <= 10) { PunktyGracz += karta.Wartosc; }
                else { PunktyGracz += 10; }

            }
            foreach (Karta karta in PlayerHand.Where(x => x.Wartosc == 1))
            {
                if (PunktyGracz + 11 + (1 * (PlayerHand.Where(x => x.Wartosc == 1).Count()) - 1) > 21) { PunktyGracz++; } else { PunktyGracz += 11; }
            }

            PunktyDealera = 0;
            foreach (Karta karta in DealerHand.Where(x => x.Wartosc != 1))
            {

                if (karta.Wartosc <= 10) { PunktyDealera += karta.Wartosc; }
                else { PunktyDealera += 10; }

            }

            foreach (Karta karta in DealerHand.Where(x => x.Wartosc == 1))
            {
                if (PunktyDealera + 11 + (1 * (DealerHand.Where(x => x.Wartosc == 1).Count()) - 1) > 21) { PunktyDealera++; } else { PunktyDealera += 11; }
            }


        }

        public void GameOutcome()
        {
            GameOver = true;
            LiczPunkty();
            if (PunktyGracz > 21) { Komunikat="Gracz Przegrywa";  GameOver = true; Przegrana(); }
            else
            {
                if(PunktyDealera > 21) { Komunikat = "Gracz Wygrywa"; GameOver = true;  Wygrana(); }
                    else
                    {
                        if (PunktyDealera < PunktyGracz) { Komunikat = "Gracz Wygrywa"; GameOver = true; Wygrana(); }
                        else
                        {
                            if (PunktyGracz < PunktyDealera) { Komunikat = "Gracz Pzegrywa"; GameOver = true; Przegrana(); } else { Komunikat = "Remis"; GameOver = true; Remis(); };
                        }
                    }
            }
        }

        public void PlayerHit()
        {
            FirstAction = false;
            PlayerDodajKarte();
            LiczPunkty();
            if (PunktyGracz > 21) GameOutcome();
        }

        public void PlayerStays()
        {
            FirstAction = false;
            GameOver = true;
            DealerLogic();
            GameOutcome();
        }

        public void PlayerDoubleDown()
        {

            if (FirstAction)
            {
                FirstAction = false;
                if (Zetony >= (2 * BetSize)) { BetSize = (BetSize * 2); PlayerDodajKarte(); PlayerStays(); }
                else { Komunikat = "Masz zbyt mało żetonów!"; }

            }
            else { Komunikat = "DoubleDown moze zostac wykonany tylko na początku gry!"; }
        }

        public void BlackJackCheck()
        {
            if (FirstAction&&PunktyGracz==21){ Komunikat = $"Masz BlackJack-a Wygrałeś {((BetSize / 2) * 3)} żetonów!"; Zetony += ((BetSize / 2) * 3); GameOver = true; }
        }

        public void DealerLogic()
        {
            while ((PunktyDealera < 16) && ((PunktyDealera < PunktyGracz) && (PunktyGracz <= 21))) { DealerDodajKarte(); LiczPunkty(); }

        }
        public void Przegrana()
        {
            Zetony -= BetSize;
        }
        public void Remis() { }
        public void Wygrana() { Zetony += BetSize; }

    }
}


