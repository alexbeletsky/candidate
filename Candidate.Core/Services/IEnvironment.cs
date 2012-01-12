using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Candidate.Core.Utils;
using ICSharpCode.SharpZipLib.Zip;

namespace Candidate.Core.Services
{
    public interface IEnvironment
    {
        void Prepare(string pathToLocalResources);
    }

    public class Environment : IEnvironment
    {
        public void Prepare(string pathToLocalResources)
        {
            var directoryHelper = DirectoryHelper.For();
            var rootDirectory = directoryHelper.RootDirectory;

            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }

            var nunitTools = Path.Combine(pathToLocalResources, "nunit.2.5.10.tools.zip");
            
            new FastZip().ExtractZip(nunitTools, directoryHelper.NUnitToolDirectory, null);
        }
    }
}
