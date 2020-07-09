using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Player;

namespace theGameBoard
{
    /*
     *  Class for the "Game board" this will hold all the players and the game state.
     *  Also creates a unique ID everytime a new gameboard is created 
     * 
     *  TODO get the game ID to the webserver
     * 
     *  default to EDH
     */
    public class GameBoard
    {
        public Dictionary<int, player> Players;
        public string GameID;

        public int Cap;

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

        public void newPlayer(string username, string gameCode)
        {
            if (gameCode.ToUpper() == GameID) {
                player newP;
                if (Players.Count == 0)
                    newP = new player(0, username, gameCode, 40);
                else
                    newP = new player(Players.Keys.Max() + 1, username, gameCode, 40);
               
                if(Players.Count < this.Cap)
                {
                    Players.Add(newP.getID(), newP);
                } else

                    Console.WriteLine("Error maximum amount of players reached");
            }
            else
            {
                Console.WriteLine("GameCode Incorrect");
            }
        }

        public void SetCap(int a){
            this.Cap = a;      
        }
        public int GetCap()
        {
            return this.Cap;
        }


    }
}
