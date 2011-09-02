using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidate.Areas.Dashboard.Models {
    public class GithubHookPayload {
        public string Ref { get; set; }

        public string Branch {
            get {
                return Ref.Split('/').Last();                    
            }
        }
    }
}