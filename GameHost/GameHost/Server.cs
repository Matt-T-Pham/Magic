using System;
using System.Data;
using Player;
using theGameBoard;

namespace GameHost
{
    /*
     * 
     * Creates a server on start up.
     * TODO:get the server ID to the website.
     */
    class Server
    {

        public static GameBoard gameBoard;
       

        static void Main(string[] args)
        {
            Server ser = new Server();

            update();          
        }

        private static void update()
        {
            Console.WriteLine(gameBoard.getGameID());
        }

        public Server()
        {
            gameBoard = new GameBoard();

        }
    }
}