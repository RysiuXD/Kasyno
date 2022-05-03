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

        public BlackJackGame() 
        {
            PlayerHand = new List<Karta>();
            DealerHand = new List<Karta>();
            Talia = new Talia();
            Talia.Tasuj();
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
            DealerDodajKarte();
            DealerDodajKarte();
            PlayerDodajKarte();
            PlayerDodajKarte();
        }

    }
}


