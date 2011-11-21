using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Candidate.Core.Settings.Validation {
    public class IisBindingsAttribute : ValidationAttribute {

        //private readonly string pattern = @"http|ftp:\*|\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,5}:\w";

        public override bool IsValid(object value) {
            //var bindings = (string)value;

            //if (Regex.IsMatch(bindings, pattern)) {
            //    return true;
            //}

            //return false;

            return true;
        }

    }
}
