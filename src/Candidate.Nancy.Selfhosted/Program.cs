using System;
using Candidate.Nancy.Selfhosted.App;
using Nancy.Hosting.Self;

namespace Candidate.Nancy.Selfhosted
{
    class Program
    {
        private static NancyHost _host;

        static void Main(string[] args)
        {
            StartHost();
        }

        private static void StartHost()
        {
            var logger = new ConsoleLogger();
            var bootstarapper = new Bootstrapper(logger);
            var uri = new Uri("http://localhost:12543");
            
            logger.Info("Staring app the server...");
            
            _host = new NancyHost(uri, bootstarapper);
            _host.Start();

            logger.Success(string.Format("Candidate has been started up on: {0}", uri.AbsoluteUri));
            logger.Success("Press CTRL+C to stop the server.");

            Console.CancelKeyPress += (s, e) => StopHost(s, e, logger);
            while(true)
            {
                Console.ReadKey();
            }
        }

        private static void StopHost(object sender, ConsoleCancelEventArgs consoleCancelEventArgs, ConsoleLogger logger)
        {
            logger.Success("Candidate has been stopped by user request.\n");
            _host.Stop();
        }

    }
}
