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
using System.Transactions;

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

            Console.WriteLine(gameBoard.getGameID());




            /*
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
            */



            update();


        
        }

        private static void update()
        {
            string input = Console.ReadLine();
            while (input != "exit")
            {
                //sockets.ToList().ForEach(s => s.Send(input));
                switch (input)
                {
                    case "NP":
                        Console.WriteLine("enter Username");
                        string username = Console.ReadLine();
                        Console.WriteLine("enter gamecode");
                        string gameCode = Console.ReadLine();
                        gameBoard.newPlayer(username,gameCode);
                        foreach (KeyValuePair<int, player> s in gameBoard.getPlayers())
                            Console.WriteLine("Key: " + s.Key + " Value: " + s.Value.getPlayerName());
                        break;
                }
                input = Console.ReadLine();
            }
        }

    }
}