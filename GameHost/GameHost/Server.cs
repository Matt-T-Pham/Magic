using System;
using System.Data;
using System.Net.Sockets;
using Player;
using theGameBoard;
using Fleck;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

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
            gameBoard = new GameBoard();

            update();


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
                    var parsedOBJ = JObject.Parse(message);                                                         

                    if ((parsedOBJ.SelectToken("password")).ToString() == gameBoard.getGameID())
                    {
                        foreach(IWebSocketConnection s in sockets)
                        {
                            if(s == socket)
                                socket.Send("1");
                        }                      
                    }
                    else
                    {
                        foreach (IWebSocketConnection s in sockets)
                        {
                            if (s == socket)
                                socket.Send("0");
                        }
                    }                      
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