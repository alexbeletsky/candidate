using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations.Parts;
using Candidate.Core.Configurations.Types;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    public class IsConfiguredTests
    {
        public class XCopyTests
        {
            [Test]
            public void should_be_configured_if_all_data_in_place()
            {
                var xcopy = new XCopyConfiguration {Github = new Github {Branch = "xx", Url = "xx"}, Iis = new Iis { SiteName = "x", DeployDirectory = "c:\\sites" }};

                Assert.That(xcopy.IsConfigured(), Is.True);
            }

            [Test]
            public void should_fail_if_github_branch_is_missing()
            {
                var xcopy = new XCopyConfiguration { Github = new Github { Url = "xx" }, Iis = new Iis { SiteName = "x", DeployDirectory = "c:\\sites" } };

                Assert.That(xcopy.IsConfigured(), Is.False);                
            }

            [Test]
            public void should_fail_if_iss_site_is_missing()
            {
                var xcopy = new XCopyConfiguration { Github = new Github { Branch = "1", Url = "xx" }, Iis = new Iis { DeployDirectory = "c:\\sites" } };

                Assert.That(xcopy.IsConfigured(), Is.False);                                
            }
        }

        public class VisualStudioTests
        {
            [Test]
            public void should_be_configured_if_all_data_in_place()
            {
                var vs = new VisualStudioConfiguration { Github = new Github { Branch = "xx", Url = "xx" }, Iis = new Iis { SiteName = "x", DeployDirectory = "c:\\sites" }, Solution = new Solution { Name = "s", WebProject = "w" }};

                Assert.That(vs.IsConfigured(), Is.True);                
            }

            [Test]
            public void should_if_solution_name_is_missing()
            {
                var vs = new VisualStudioConfiguration { Github = new Github { Branch = "xx", Url = "xx" }, Iis = new Iis { SiteName = "x", DeployDirectory = "c:\\sites" }, Solution = new Solution { WebProject = "w" } };

                Assert.That(vs.IsConfigured(), Is.False);                                
            }

            [Test]
            public void should_if_web_project_is_missing()
            {
                var vs = new VisualStudioConfiguration { Github = new Github { Branch = "xx", Url = "xx" }, Iis = new Iis { SiteName = "x", DeployDirectory = "c:\\sites" }, Solution = new Solution { Name = "n"} };

                Assert.That(vs.IsConfigured(), Is.False);
            }
        }

        public class BatchTests
        {
            [Test]
            public void should_be_configured_if_all_data_in_place()
            {
                var batch = new BatchConfiguration { Github = new Github { Branch = "xx", Url = "xx" }, Iis = new Iis { SiteName = "x", DeployDirectory = "c:\\sites" }, Batch = new Batch { BuildDirectory = "x", BuildScript = "y "}};

                Assert.That(batch.IsConfigured(), Is.True);
            }            

            [Test]
            public void should_fail_if_build_directory_is_missing()
            {
                var batch = new BatchConfiguration { Github = new Github { Branch = "xx", Url = "xx" }, Iis = new Iis { SiteName = "x", DeployDirectory = "c:\\sites" }, Batch = new Batch { BuildScript = "y" } };

                Assert.That(batch.IsConfigured(), Is.False);
            }

            [Test]
            public void should_fail_if_build_script_is_missing()
            {
                var batch = new BatchConfiguration { Github = new Github { Branch = "xx", Url = "xx" }, Iis = new Iis { SiteName = "x", DeployDirectory = "c:\\sites" }, Batch = new Batch { BuildDirectory = "x" } };

                Assert.That(batch.IsConfigured(), Is.False);
            }            

        }
    }
}
