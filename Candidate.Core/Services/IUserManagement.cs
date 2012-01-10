using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Account;

namespace Candidate.Core.Services
{
    public interface IUserManagement
    {
        User Current();
        void Create(string login, string password);
    }
}
