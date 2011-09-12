using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidate.Infrustructure.Authentication {
    public class UserSettings {
        public UserSettings() {
            Users = new List<User> { new User { Login = "admin", PasswordHash = "21232f297a57a5a743894a0e4a801fc3" } };
        }

        public IList<User> Users { get; set; }
    }
}