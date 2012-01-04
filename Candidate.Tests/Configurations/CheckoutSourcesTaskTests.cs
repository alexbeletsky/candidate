using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations.Tasks;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    class CheckoutSourcesTaskTests
    {
        [Test]
        public void should_create_checkout_sources_task()
        {
            // arrange
            var task = new CheckoutSourcesTask("git@git.com", "master", @"c:\development\projects\src\" );

            // act
            var bounceTask = task.ToTask();

            // assert
            Assert.That(bounceTask.Branch.Value, Is.EqualTo("master"));
            Assert.That(bounceTask.Repository.Value, Is.EqualTo("git@git.com"));
            Assert.That(bounceTask.Directory.Value, Is.EqualTo(@"c:\development\projects\src\"));
        }
    }
}
