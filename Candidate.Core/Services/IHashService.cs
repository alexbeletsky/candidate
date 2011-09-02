using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Services
{
    public interface IHashService
    {
        string CreateMD5Hash(string value);
        bool ValidateMD5Hash(string value, string hash);
    }
}
