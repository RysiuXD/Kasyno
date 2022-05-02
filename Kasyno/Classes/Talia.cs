using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasyno.Classes
{
    public class Talia
    {
        static string[] KolorArray = { "♥", "♦", "♠", "♣" };
        public List<Karta> Karty = new List<Karta>();

        public Talia()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Karty.Add(new Karta(j, KolorArray[i]));
                }
            }
        }
        public void Tasuj()
        {
            for (int i = 0; i < 101; i++)
            {
                var rnd = new Random();
                var TasowanaKarta = Karty[rnd.Next(0, Karty.Count())];
                this.Karty.Remove(TasowanaKarta);
                this.Karty.Add(TasowanaKarta);

            }
        }
    }
}
