using System;
using System.IO;
using Nancy;

namespace Candidate.Nancy.Selfhosted.App
{
    public class PathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return Path.Combine(Environment.CurrentDirectory, @"..\");
        }
    }
}
