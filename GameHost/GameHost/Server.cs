using System;
using System.Data;
using System.Net.Sockets;
using Player;
using theGameBoard;
using Fleck;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace GameHost
{
    /*
     * Creates a server on start up.
     * TODO:get the server ID to the website.
     */
    class Server
    {

        public static GameBoard gameBoard;
        

        static void Main(string[] args)
        {
            Server ser = new Server();

            FleckLog.Level = LogLevel.Debug;
            var sockets = new List<IWebSocketConnection>();
            var _server = new WebSocketServer("ws://127.0.0.1:8181");

            _server.Start(socket =>{
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    sockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    sockets.Remove(socket);
                    Console.WriteLine("Close!");
                };
                socket.OnMessage = message =>
                {
                    Console.WriteLine("client says: " + message);
                    sockets.ToList().ForEach(s => s.Send("client says: " + message));              
                };
            });

            string input = Console.ReadLine();

            while (input != "exit")
            {
                sockets.ToList().ForEach(s => s.Send(input));
                input = Console.ReadLine();
            }

        
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