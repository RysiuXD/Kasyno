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
        public int PunktyGracz, PunktyDealera;
        public string Komunikat;
        public bool GameOver;

        public BlackJackGame() 
        {
            Komunikat = "Dealer dobiera do 16.";
            PlayerHand = new List<Karta>();
            DealerHand = new List<Karta>();
            Talia = new Talia();
            Talia.Tasuj();
            GameOver = false;
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
            GameOver = false;
            ZbierzKarty();
            DealerDodajKarte();
            DealerDodajKarte();
            PlayerDodajKarte();
            PlayerDodajKarte();
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
            LiczPunkty();
            if (PunktyGracz > 21) { Komunikat="Gracz Przegrywa";  GameOver = true; }
            else
            {
                if(PunktyDealera > 21) { Komunikat = "Gracz Wygrywa"; GameOver = true; }
                    else
                    {
                        if (PunktyDealera < PunktyGracz) { Komunikat = "Gracz Wygrywa"; GameOver = true; }
                        else
                        {
                            if (PunktyGracz < PunktyDealera) { Komunikat = "Gracz Pzegrywa"; GameOver = true; } else { Komunikat = "Remis"; GameOver = true; };
                        }
                    }
            }
        }




        public void PlayerHit()
        {
            PlayerDodajKarte();
            LiczPunkty();
            if (PunktyGracz > 21) GameOutcome();
        }
    }
}


