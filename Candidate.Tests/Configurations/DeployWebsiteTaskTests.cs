using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations.Tasks;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    public class DeployWebsiteTaskTests
    {
        [Test]
        public void should_create_deploy_website_task()
        {
            // arrange
            var task = new DeployWebsiteTask(@"c:\sites\xcopy-project", "xcopy-site-name", 2011);

            // act
            var bounceTask = task.ToTask();

            // assert
            Assert.That(bounceTask.Directory.Value, Is.EqualTo(@"c:\sites\xcopy-project"));
            Assert.That(bounceTask.Name.Value, Is.EqualTo(@"xcopy-site-name"));
            Assert.That(bounceTask.Port.Value, Is.EqualTo(2011));
        }
    }
}
