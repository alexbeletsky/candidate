using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Candidate.Areas.Dashboard.Models {
    public class AccountSettingsModel {
        [Required]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required]
        [DisplayName("New password")]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}