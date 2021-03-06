﻿using System;
using Candidate.Nancy.Selfhosted.App;
using Nancy.Hosting.Self;
using Candidate.Core.Logger;

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

            logger.Info("Candidate - Deployment Automation Server v.0.2.0\n");
            logger.Info("Initializing, please wait unit server ready (up to 5 seconds)...");
            
            var bootstarapper = new Bootstrapper(logger);
            var uri = new Uri("http://localhost:12543");

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
