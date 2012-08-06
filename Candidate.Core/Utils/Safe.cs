using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Candidate.Core.Utils
{
    public static class Safe
    {
        public static void DirectoryDelete(string path)
        {
            SafeOperation(() => Directory.Delete(path, true));
        }

        public static void SafeOperation(Action action)
        {
            try
            {
                action();
            } 
            catch
            {
            }
        }
    }
}
