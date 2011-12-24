using System;
using System.IO;
using System.Linq;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Setup;
using Candidate.Core.Utils;
using ICSharpCode.SharpZipLib.Zip;
using NUnit.Framework;
using SharpTestsEx;

namespace Candidate.Tests.Setup
{
    [TestFixture]
    public class ConfigObjectBuilderTests
    {
        private static string CurrentDirectory = Directory.GetCurrentDirectory();
        private IDirectoryProvider DirectoryProvider = new DirectoryProvider("ConfigObjectBuilderTests", CurrentDirectory);

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateConfigObject_For_Null_Throws_Exception()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);

            // act
            var configObject = configObjectBuilder.CreateConfigObject(null);
        }

        [Test]
        public void CreateConfigObject_For_Git_Creates_Object_With_Git()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Github = new Github { Url = "git://myhost/repo.git", Branch = "master" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.CheckoutSources, Is.Not.Null);
            Assert.That(configObject.CheckoutSources.Repository.Value, Is.EqualTo("git://myhost/repo.git"));
        }

        [Test]
        public void CreateConfigObject_For_Git_Directory_Is_Inited()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Github = new Github { Url = "git://myhost/repo.git", Branch = "master" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.CheckoutSources.Directory.Value, Is.Not.Null);
            Assert.That(configObject.CheckoutSources.Directory.Value, Is.EqualTo(DirectoryProvider.Sources));
        }

        [Test]
        public void CreateConfigObject_For_Git_With_Out_Url_Config_Object_Not_Created()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Github = new Github { Branch = "master" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.CheckoutSources, Is.Null);
        }

        [Test]
        public void CreateConfinObject_For_Git_With_Branch_Config_Object_Created()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Github = new Github { Url = "git://myhost/repo.git", Branch = "master" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.CheckoutSources.Branch.Value, Is.Not.Null);
            Assert.That(configObject.CheckoutSources.Branch.Value, Is.EqualTo("master"));
        }

        [Test]
        public void CreateConfinObject_For_Git_With_Branch_If_Branch_Not_Set_Config_Object_Branch_Is_Null()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Github = new Github { Url = "git://myhost/repo.git" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.CheckoutSources.Branch.Value, Is.Null);
        }

        [Test]
        public void CreateConfigObject_For_Solution_If_Git_Is_Defined_Create_Object_With_Solution()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Github = new Github { Url = "git://myhost/repo.git", Branch = "master" }, Solution = new Solution { Name = "TestSolution\\Test.sln" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.BuildSolution, Is.Not.Null);
            Assert.That(configObject.BuildSolution.SolutionPath.Value, Is.EqualTo(DirectoryProvider.Sources + "\\TestSolution\\Test.sln"));
        }

        [Test]
        public void CreateConfigObject_For_Solution_If_Git_Is_Not_Defined_Create_Object_With_Solution()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.BuildSolution, Is.Not.Null);
            Assert.That(configObject.BuildSolution.SolutionPath.Value, Is.EqualTo(DirectoryProvider.Sources + "\\TestSolution\\Test.sln"));
        }

        [Test]
        public void CreateConfigObject_For_Solution_Output_Directory_Is_Set()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.BuildSolution.OutputDir.Value, Is.EqualTo(DirectoryProvider.Build));
        }

        [Test]
        public void CreateConfigObject_For_Solution_Target_Depends_On_Selected_Target_Rebuild()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln", SelectedTarget = 1 } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.BuildSolution.Target.Value, Is.EqualTo("Rebuild"));
        }

        [Test]
        public void CreateConfigObject_For_Solution_Target_Depends_On_Selected_Target_Build()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln", SelectedTarget = 0 } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.BuildSolution.Target.Value, Is.EqualTo("Build"));
        }

        [Test]
        public void CreateConfigObject_For_Solution_Configuration_Depends_On_Selected_Configuration_Debug()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln", SelectedConfiguration = 0 } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.BuildSolution.Configuration.Value, Is.EqualTo("Debug"));
        }

        [Test]
        public void CreateConfigObject_For_Solution_Configuration_Depends_On_Selected_Configuration_Release()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln", SelectedConfiguration = 1 } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.BuildSolution.Configuration.Value, Is.EqualTo("Release"));
        }

        [Test]
        [ExpectedException]
        public void CreateConfigObject_For_Iis_Defined_If_No_Solution_Throws_Exception()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Iis = new Iis { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);
        }

        [Test]
        [ExpectedException]
        public void CreateConfig_For_Iis_If_No_Webproject_Name_Throws_Exception()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln" }, Iis = new Iis { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);
        }

        [Test]
        public void CreateConfigObject_For_Iis_If_Defined_Create_Iis_Web_Site_Object()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln", WebProject = "Test" }, Iis = new Iis { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.DeployWebsite, Is.Not.Null);
            Assert.That(configObject.DeployWebsite.Name.Value, Is.EqualTo("TestSite"));
        }

        [Test]
        public void CreateConfigObject_For_Iis_If_Defined_With_Web_Project_Create_Iis_Web_Site_Object()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln", WebProject = "Test" }, Iis = new Iis { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.DeployWebsite, Is.Not.Null);
            Assert.That(configObject.DeployWebsite.Name.Value, Is.EqualTo("TestSite"));
            Assert.That(configObject.DeployWebsite.Directory.Value, Is.EqualTo("c:\\sites\\TestSite"));
        }

        [Test]
        public void CreateConfigObject_For_Iis_If_Defined_Default_Port_Is_8081()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln", WebProject = "Test" }, Iis = new Iis { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.DeployWebsite, Is.Not.Null);
            Assert.That(configObject.DeployWebsite.Port.Value, Is.EqualTo(80));
        }

        [Test]
        public void CreateConfigObject_For_Iis_Defined_And_Port_Set_SetPort()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Solution = new Solution { Name = "TestSolution\\Test.sln", WebProject = "Test" }, Iis = new Iis { SiteName = "TestSite", Port = 9000 } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.DeployWebsite, Is.Not.Null);
            Assert.That(configObject.DeployWebsite.Port.Value, Is.EqualTo(9000));
        }

        [Test]
        public void CreateConfigObject_For_Iss_If_Binding_Is_Defined_Add_Binding_Info()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Iis = new Iis { SiteName = "test", DeployFolder = "c:\\sites", Bindings = "http:*:80:site.com" }, Solution = new Solution { Name = "TestSolution\\Test.sln", WebProject = "Test" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            configObject.DeployWebsite.Bindings.Value.First().Protocol.Value.Should().Be("http");
            configObject.DeployWebsite.Bindings.Value.First().Information.Value.Should().Be("*:80:site.com");
        }

        [Test]
        public void CreateConfigObject_For_Iss_If_Binding_Is_Defined_Add_Binding_Info_Ftp()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Iis = new Iis { SiteName = "test", DeployFolder = "c:\\sites", Bindings = "ftp:*:80:site.com" }, Solution = new Solution { Name = "TestSolution\\Test.sln", WebProject = "Test" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            configObject.DeployWebsite.Bindings.Value.First().Protocol.Value.Should().Be("ftp");
            configObject.DeployWebsite.Bindings.Value.First().Information.Value.Should().Be("*:80:site.com");
        }

        [Test]
        public void CreateConfigObject_For_Iss_If_Binding_Is_Defined_Add_Binding_Info_With_Ip_Address()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Iis = new Iis { SiteName = "test", DeployFolder = "c:\\sites", Bindings = "ftp:127.0.0.1:80:site.com" }, Solution = new Solution { Name = "TestSolution\\Test.sln", WebProject = "Test" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            configObject.DeployWebsite.Bindings.Value.First().Protocol.Value.Should().Be("ftp");
            configObject.DeployWebsite.Bindings.Value.First().Information.Value.Should().Be("127.0.0.1:80:site.com");
        }

        [Test]
        public void CreateConfigObject_For_Iis_Binding_Contains_Several_Records()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Iis = new Iis { SiteName = "test", DeployFolder = "c:\\sites", Bindings = "http:127.0.0.1:80:site.com;ftp:127.0.0.1:80:ftp.site.com" }, Solution = new Solution { Name = "TestSolution\\Test.sln", WebProject = "Test" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            configObject.DeployWebsite.Bindings.Value.Skip(1).Take(1).First().Protocol.Value.Should().Be("ftp");
            configObject.DeployWebsite.Bindings.Value.Skip(1).Take(1).First().Information.Value.Should().Be("127.0.0.1:80:ftp.site.com");
        }

        [Test]
        public void should_create_simple_run_task_if_post_batch_is_set()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Github = new Github { Url = "git@git.com" }, Post = new Post { Batch = "run.bat" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.PostBuildBatch.Exe.Value, Is.EqualTo("run.bat"));
            Assert.That(configObject.PostBuildBatch.WorkingDirectory.Value, Is.EqualTo(DirectoryProvider.Sources));
        }


        [Test]
        public void should_create_simple_run_task_if_pre_batch_is_set()
        {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new VisualStudioConfiguration { Github = new Github { Url = "git@git.com" }, Pre = new Pre { Batch = "run.bat" } };
            
            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.PreBuildBatch.Exe.Value, Is.EqualTo("run.bat"));
            Assert.That(configObject.PreBuildBatch.WorkingDirectory.Value, Is.EqualTo(DirectoryProvider.Sources));
        }
    }
}
