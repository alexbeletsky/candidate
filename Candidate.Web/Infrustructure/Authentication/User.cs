using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidate.Infrustructure.Authentication {
    public class User {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public bool TemporaryPassword { get; set; }
    }
}