using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

// http://msdn.microsoft.com/en-us/library/system.security.cryptography.md5.aspx
// https://gist.github.com/734467#comments

namespace Candidate.Core.Services
{
    public class HashService : IHashService
    {
        public string CreateMD5Hash(string input)
        {
            using (var crypter = System.Security.Cryptography.MD5.Create())
            {
                return string.Join("", crypter.ComputeHash(Encoding.Default.GetBytes(input)).Select(byt => byt.ToString("x2")));
            }
        }

        public bool ValidateMD5Hash(string input, string hash)
        {
            return (StringComparer.OrdinalIgnoreCase.Compare(CreateMD5Hash(input), hash) == 0);
        }
    }
}
