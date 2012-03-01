using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Web.Administration;

namespace Bounce.Framework
{
    public class Iis7StartedSite : Task
    {
        [Dependency]
        public Task<string> Name;
        [Dependency]
        public Task<TimeSpan> Wait;

        public Iis7StartedSite()
        {
            Wait = TimeSpan.FromMilliseconds(0);
        }

        public override void Build()
        {
            var iisServer = new ServerManager();
            var site = iisServer.Sites[Name.Value];

            if (site != null)
            {
                try
                {
                    site.Start();
                    Thread.Sleep(Wait.Value);
                }
                catch
                {
                    // seems IIS 7.5 has bug of starting up site first time..
                    // http://improve.dk/archive/2009/07/08/iis7-the-object-identifier-does-not-represent-a-valid-object.aspx
                }
            }
        }
    }
}
