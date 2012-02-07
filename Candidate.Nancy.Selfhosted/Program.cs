using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Hosting.Self;

namespace Candidate.Nancy.Selfhosted
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new NancyHost(new Uri("http://localhost:1111"));
            host.Start(); // start hosting

            Console.ReadKey();
            host.Stop();
        }
    }
}
