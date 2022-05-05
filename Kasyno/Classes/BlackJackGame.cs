using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasyno.Classes
{
    public class BlackJackGame
    {
        public List<Karta> PlayerHand, DealerHand, SplitHand;
        public Talia Talia;
        public int PunktyGracz, PunktyDealera, Zetony, BetSize;
        public string Komunikat;
        public bool GameOver, FirstAction, PlayerSplited, SplitGameOver;

        public BlackJackGame() 
        {
            Komunikat = "Dealer dobiera do 16.";
            PlayerHand = new List<Karta>();
            DealerHand = new List<Karta>();
            SplitHand = new List<Karta>();
            Talia = new Talia();
            Talia.Tasuj();
            GameOver = false;
            PlayerSplited = false;
            SplitGameOver = true;
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
            if (Zetony >= BetSize)
            {
                Komunikat = "Dealer dobiera do 16";
                GameOver = false;
                FirstAction = true;
                PlayerSplited = false;
                ZbierzKarty();
                DealerDodajKarte();
                DealerDodajKarte();
                PlayerDodajKarte();
                PlayerDodajKarte();
                LiczPunkty();
                BlackJackCheck();
            }
            else 
            { Komunikat = "Masz zbyt mało żetonów"; }
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
            foreach (Karta karta in SplitHand)
            {
                Talia.Karty.Add(karta);
            }
            SplitHand.Clear();
            
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
            LiczPunkty();
            if (PunktyGracz > 21) { Przegrana(); }
            else
            {
                if(PunktyDealera > 21) { Wygrana(); }
                    else
                    {
                        if (PunktyDealera < PunktyGracz) { Wygrana(); }
                        else
                        {
                            if (PunktyGracz < PunktyDealera) { Przegrana(); } else { ; Remis(); };
                        }
                    }
            }
        }

        public void PlayerHit()
        {
            FirstAction = false;
            PlayerDodajKarte();
            LiczPunkty();
            if (PunktyGracz > 21 && !PlayerSplited) { GameOutcome(); }
            if (PunktyGracz > 21 && PlayerSplited) { ChangeHand(); SplitGameOver = true; Komunikat = $"Przegrałeś {BetSize} zetonow w jednej ręce"; }
        }

        public void PlayerStays()
        {
            FirstAction = false;
            DealerLogic();
            GameOutcome();
        }

        public void PlayerDoubleDown()
        {

            if (FirstAction)
            {
                FirstAction = false;
                if (Zetony >= (2 * BetSize)) { BetSize = (BetSize * 2); PlayerDodajKarte(); PlayerStays(); BetSize = (BetSize / 2); }
                else { Komunikat = "Masz zbyt mało żetonów!"; }

            }
            else { Komunikat = "DoubleDown moze zostac wykonany tylko na początku gry!"; }
        }


        public void PlayerSplit()
        {
            
            if (Zetony < (BetSize * 2)) { Komunikat = "Masz zbyt mało żetonów na Split!"; }
            else
            {
                if (PlayerHand[0].Wartosc != PlayerHand[1].Wartosc) { Komunikat = "Nie masz odpowiednich kart na Split!"; }
                else
                {
                    FirstAction = false;
                    PlayerSplited = true;
                    SplitGameOver = false;
                    var cardHolder = PlayerHand[1];
                    PlayerHand.Remove(cardHolder);
                    SplitHand.Add(cardHolder);
                    cardHolder = Talia.Karty.First();
                    PlayerHand.Add(cardHolder);
                    Talia.Karty.Remove(cardHolder);
                    cardHolder = Talia.Karty.First();
                    SplitHand.Add(cardHolder);
                    Talia.Karty.Remove(cardHolder);
                }
            }
        }

        public void ChangeHand()
        {
            if (PlayerSplited)
            {
                if (!SplitGameOver)
                {
                    var temphand = new List<Karta>();
                    temphand = PlayerHand;
                    PlayerHand = SplitHand;
                    SplitHand = temphand;
                }
                else 
                { Komunikat = "Druga ręka została już rozegrana"; }
            }
        }

        public void BlackJackCheck()
        {
            if (FirstAction&&PunktyGracz==21){ Komunikat = $"Masz BlackJack-a Wygrałeś {((BetSize / 2) * 3)} żetonów!"; Zetony += ((BetSize / 2) * 3); GameOver = true; }
        }

        public void DealerLogic()
        {
            LiczPunkty();
            while ((PunktyDealera < 16) && ((PunktyDealera < PunktyGracz) && (PunktyGracz <= 21))) { DealerDodajKarte(); LiczPunkty(); }

        }
        public void Przegrana()
        {
            if (!PlayerSplited)
            {
                Komunikat = $"Gracz Przegrywa {BetSize} zetonów";
                Zetony -= BetSize;
                GameOver = true;
            }
            else
            { 
                if (SplitGameOver)
                {
                    Komunikat += $"\n Druga Ręka: Przegrałeś  {BetSize} żetonów!"; Zetony -= BetSize; GameOver = true;
                }
                else
                {
                    Komunikat = $"\n Pierwsza Ręka: Przegrałeś  {BetSize} żetonów!"; Zetony -= BetSize; ChangeHand(); SplitGameOver = true; GameOutcome();
                }
            }
            
        }
        public void Remis()
        {
            if (!PlayerSplited)
            {
                Komunikat = "Remis";
                GameOver = true;
            }
            else
            {
                if (SplitGameOver)
                {
                    Komunikat += $"\n Druga Ręka: Remis"; GameOver = true;
                }
                else
                {
                    Komunikat = $"\n Pierwsza Ręka: Remis "; ChangeHand(); SplitGameOver = true; GameOutcome();
                }
            }
        }
        public void Wygrana() 
        {
            if (!PlayerSplited)
            {
                Komunikat = $"Gracz Wygrywa {BetSize} zetonów";
                Zetony += BetSize;
                GameOver = true;
            }
            else
            {
                if (SplitGameOver)
                {
                    Komunikat += $"\n Druga Ręka: Wygrwya {BetSize} żetonów!"; Zetony += BetSize; GameOver = true;
                }
                else
                {
                    Komunikat = $"\n Pierwsza Ręka: Wygrywa  {BetSize} żetonów!"; Zetony += BetSize; ChangeHand(); SplitGameOver = true; GameOutcome();
                }
            }
        }


        public void RiseBet() { if (GameOver) { if (Zetony > BetSize) { BetSize += 10; Komunikat = ""; } else { Komunikat = "Masz za mało żetonów by podnieść stawke"; } } else { Komunikat = "Kwote zakładu można zmienać tylko pomiędzy rozdaniami!"; } }
        public void LowerBet() { if (GameOver) { if (BetSize >= 20) { BetSize -= 10; Komunikat = ""; } else { Komunikat = "10 to minimalna kwota zakładu"; } } else { Komunikat = "Kwote zakładu można zmienać tylko pomiędzy rozdaniami!"; } }

    }
}


