using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations.Tasks;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    public class CopyToDestinationTaskTests
    {
        [Test]
        public void should_create_copy_to_destination_task()
        {
            // arrange
            var task = new CopyToDestinationTask(@"c:\development\projects\a\src", @"c:\sites", "simple-deploy");

            // act
            var bounceTask = task.ToTask();

            // assert
            Assert.That(bounceTask.FromPath.Value, Is.EqualTo(@"c:\development\projects\a\src"));
            Assert.That(bounceTask.ToPath.Value, Is.EqualTo(@"c:\sites\simple-deploy"));
            Assert.That(bounceTask.Excludes.Value.Contains(".git"), Is.True);
        }

        [Test]
        public void should_delete_to_folder()
        {
            // arrange
            var task = new CopyToDestinationTask(@"c:\development\projects\a\src", @"c:\sites", "simple-deploy");

            // act
            var bounceTask = task.ToTask();

            // assert
            Assert.That(bounceTask.DeleteToDirectory.Value, Is.True);
        }
    }
}
