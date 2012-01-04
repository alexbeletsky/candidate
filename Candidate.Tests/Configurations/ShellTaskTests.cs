using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations.Tasks;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    public class ShellTaskTests
    {
        [Test]
        public void should_create_shell_task()
        {
            // arrange
            var task = new ShellTask("batch", "sources");

            // act
            var bounceTask = task.ToTask();

            // assert
            Assert.That(bounceTask.Exe.Value, Is.EqualTo("batch"));
            Assert.That(bounceTask.WorkingDirectory.Value, Is.EqualTo("sources"));
        }
    }
}
