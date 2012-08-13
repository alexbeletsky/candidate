using System;
using System.IO;
using Nancy;

namespace Candidate.Nancy.Selfhosted.App
{
    public class PathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\"));
        }
    }
}
