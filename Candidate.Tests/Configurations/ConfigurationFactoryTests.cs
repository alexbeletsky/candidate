using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations;
using Candidate.Core.Model.Configurations;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    public class ConfigurationFactoryTests
    {
        [Test]
        public void should_create_batch_configuration()
        {
            // assert
            Assert.That(CreateConfiguration(ConfigurationType.Batch), Is.TypeOf<BatchConfiguration>());
        }

        [Test]
        public void should_create_xcopyt_configuration()
        {
            // assert
            Assert.That(CreateConfiguration(ConfigurationType.XCopy), Is.TypeOf<XCopyConfiguration>());
        }

        [Test]
        public void should_create_visual_studio_configuration()
        {
            // assert
            Assert.That(CreateConfiguration(ConfigurationType.VisualStudio), Is.TypeOf<VisualStudioConfiguration>());
        }

        private static Configuration CreateConfiguration(ConfigurationType type)
        {
            return new ConfigurationsFactory().CreateConfiguration(type, "test-id", "Test Configuration");
        }

    }
}
