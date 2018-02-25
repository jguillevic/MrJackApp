using MrJackApp.WCFService.Game;
using System;
using System.ServiceModel;

namespace MrJackApp.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(GameService)))
            {
                host.Open();
                Console.WriteLine("GameService started");
                Console.ReadLine();
            }
        }
    }
}
