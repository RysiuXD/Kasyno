namespace Kasyno.Classes
{
    public class SlotMachine
    {
        public int Zetony, BetSize, Wygrana, i=0;
        public string Komunikat;
        public bool GameOver;
        string[] DoWylosowania = { "🍒", "🍇", "💰", "🔔" };
        public string[] Wylosowane = new string[3];


        public SlotMachine()
        {
            Komunikat = "Mozesz uruchomic maszyne";
            GameOver = false;
            Zetony = 200;
            BetSize = 10;
        }

        public void Losuj()
        {
            for (i=0; i < Wylosowane.Length; i++)
            {
                var rnd = new Random();
                Wylosowane[i] = DoWylosowania[rnd.Next(0, DoWylosowania.Length)];
            }
        }

        public void Game_Result()
        {
            //if(Losuj(DoWylosowane[i]))
            //{
               
            //}
            //else
            //{


            //}

        }

        public void Rozgrywka()
        {
            if (Zetony >= BetSize)
            {
                Komunikat = "Zaczynamy";
                GameOver = false;
              
                LiczZetony();
            }
            else
            { Komunikat = "Masz zbyt mało żetonów"; }
        }


        public void LiczZetony()
        {
  
        }



    }
}
