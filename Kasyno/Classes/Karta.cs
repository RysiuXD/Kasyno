using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasyno.Classes
{
    public class Karta
    {

        public string TxtColor;
        public int Wartosc;
        public string Kolor;
        public Karta(int wartosc, string kolor)
        {
            if (kolor == "♥" || kolor == "♦") { TxtColor = "red"; } else { TxtColor = "black"; }
            this.Wartosc = wartosc;
            this.Kolor = kolor;
        }

        public string GetFace()
        {
            string Face = "";
            switch (this.Wartosc)
            {
                case 1: Face += "A"; break;
                case 2: Face += "2"; break;
                case 3: Face += "3"; break;
                case 4: Face += "4"; break;
                case 5: Face += "5"; break;
                case 6: Face += "6"; break;
                case 7: Face += "7"; break;
                case 8: Face += "8"; break;
                case 9: Face += "9"; break;
                case 10: Face += "10"; break;
                case 11: Face += "J"; break;
                case 12: Face += "Q"; break;
                case 13: Face += "K"; break;
            }

            Face += this.Kolor;
            return Face;
        }
    }

}

