using System;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;

namespace Candidate.Nancy.Selfhosted
{
    class Program
    {
        private static NancyHost _host;

        static void Main(string[] args)
        {
//            Console.WriteLine(string.Format("Starting up Candidate Deployment server..."));
//
//            var directoryHelper = DirectoryHelper.For();
//            var documentStore = new EmbeddableDocumentStore { DataDirectory = directoryHelper.DatabaseDirectory };
//            documentStore.Initialize();
//
//            Console.WriteLine(string.Format("Document store has been initialized..."));

            StartHost();
        }

        private static void StartHost()
        {
            var bootstarapper = new Bootstrapper();
            var uri = new Uri("http://localhost:12543");
            _host = new NancyHost(uri, bootstarapper);
            _host.Start();

            Console.CancelKeyPress += StopHost;
            Console.ReadKey();
        }

        private static void StopHost(object sender, ConsoleCancelEventArgs e)
        {
//            Console.WriteLine("Received CTRL+C, stopping server...");
            _host.Stop();
        }
    }
}
