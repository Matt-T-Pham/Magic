using System;
using System.Collections.Generic;
using System.Text;
using Player;

namespace theGameBoard
{
    public class GameBoard
    {
        public Dictionary<int, player> Players;
        public string GameID;

        public GameBoard()
        {
            Players = new Dictionary<int, player>();
            GameIDGenerator();
        }
        public Dictionary<int, player> getPlayers()
        {
            return this.Players;
        }
        public string getGameID()
        {
            return this.GameID;
        }

        private void GameIDGenerator()
        {
            int length = 5;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            this.GameID = str_build.ToString();
        }
    }
}
