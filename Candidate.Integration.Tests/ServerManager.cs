using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.Web.Administration;

namespace Candidate.Integration.Tests {
    [TestFixture]
    [Ignore]
    public class ServerManagerTests {
        [Test]
        public void Test() {
            var manager = new ServerManager();

            var site = manager.Sites.Add("SiteFromTest", "c:\\sites", 1010);
            site.Bindings.Clear();
            site.Bindings.Add("*:90:www.xxx.com", "http");
            site.Bindings.Add("*:90:xxx.com", "http");

            manager.CommitChanges();
        }
    }
}
