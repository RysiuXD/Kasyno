namespace Kasyno.Classes
{
    public class SlotMachine
    {
        public int PunktyGracz, Zetony;
        public string Komunikat;
        public bool GameOver;
        string[] DoWylosowania = { "🍒", "🍇", "💰", "🔔" };
        public string[] Wylosowane = new string[3];

        public SlotMachine()
        {
            Komunikat = "Mozesz uruchomic maszyne";
            GameOver = false;
            Zetony = 200;

            

            

           
        }

        public void Losuj()
        {
            for (int i = 0; i < Wylosowane.Length; i++)
            {
                var rnd = new Random();
                Wylosowane[i] = DoWylosowania[rnd.Next(0, DoWylosowania.Length)];
            }
        }

    }
}
