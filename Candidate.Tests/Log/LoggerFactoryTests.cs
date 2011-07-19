using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Log;
using Moq;
using Candidate.Core.Utils;
using System.IO;

namespace Candidate.Tests.Log {
    [TestFixture]
    public class LoggerFactoryTests {

        private static string CurrentDirectory = Directory.GetCurrentDirectory();
        private static DirectoryProvider DirectoryProvider = new DirectoryProvider("LoggerFactoryTests", CurrentDirectory);

        [SetUp]
        public void Setup() {
        }

        [TearDown]
        public void Teardown() {
            DeleteTestFolder();
        }

        [Test]
        public void CreateLogger_CreatesNewInstance() {
            // arrange
            var factory = new LoggerFactory(DirectoryProvider);

            // act
            using (var logger = factory.CreateLogger()) {
                // assert
                Assert.That(logger, Is.Not.Null);
            }
        }

        [Test]
        public void CreateLogger_CreatesNewInstance_LogFileIsCreaeted() {
            // arrange
            var factory = new LoggerFactory(DirectoryProvider);

            // act
            using (var logger = factory.CreateLogger()) {
                // assert
                Assert.That(logger, Is.Not.Null);
                Assert.That(File.Exists(DirectoryProvider.Job + "\\logs\\" + logger.LogFilename), Is.True); 
            }
        }


        private void DeleteTestFolder() {
            if (Directory.Exists(DirectoryProvider.Job)) {
                Directory.Delete(DirectoryProvider.Job, true);
            }
        }
    }

}
