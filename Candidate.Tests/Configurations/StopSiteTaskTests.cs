using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations.Tasks;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    public class StopSiteTaskTests
    {
        [Test]
        public void should_stop_task_and_wait_for_1000_ms()
        {
            // arrange
            var task = new StopSiteTask("site-name");

            // act
            var bounceTask = task.ToTask();

            // assert
            Assert.That(bounceTask.Name.Value, Is.EqualTo("site-name"));
            Assert.That(bounceTask.Wait.Value, Is.EqualTo(TimeSpan.FromMilliseconds(1000)));
        }
    }
}
