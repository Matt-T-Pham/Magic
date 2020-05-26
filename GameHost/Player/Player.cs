using System;

namespace Player
{
    /*
     * 
     * Player every connection should be a new player for that specific gameboard.
     * TODO: get the webserver to display the game ID then when connected make a new person for that specific game board. 
     * 
     */
    public class player
    {
        private int playerID;
        private string playerName;
        private int gameID;
        private int hp;

        public player(int playerID, string playerName, int gameID, int hp)
        {
            this.playerID = playerID;
            this.playerName = playerName;
            this.gameID = gameID;
            this.hp = hp;
        }
        public void setID(int id)
        {
            this.playerID = id;
        }
        public int getID()
        {
            return this.playerID;
        }
        public void setPlayerName(string name)
        {
            this.playerName = name;
        }
        public string getPlayerName()
        {
            return this.playerName;
        }
        public void setGameID(int id)
        {
            this.gameID = id;
        }
        public int getGameID()
        {
            return this.gameID;
        }
        public void setHP(int hp)
        {
            this.hp = hp;
        }
        public int getHP()
        {
            return this.hp;
        }
        public void increaseHP()
        {
            this.hp++;
        }
        public void decreaseHP()
        {
            this.hp--;
        }
    }
}
