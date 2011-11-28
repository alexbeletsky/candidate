using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Helpers {
    public class BindingParserResult {
        public string Protocol { get; set; }
        public string Information { get; set; }
        public string Ip { get; set; }
        public string SiteName { get; set; }
        public string Port { get; set; }
    }
    
    public class BindingParser {
        public IEnumerable<BindingParserResult> Parse(string bindingInformation) {
            var splittedBindingString = bindingInformation.Split(';');
            foreach (var bindingString in splittedBindingString) {

                var information = bindingString.Substring(bindingString.IndexOf(":") + 1);
                var splitted = bindingString.Split(':');

                yield return new BindingParserResult {
                    Protocol = splitted[0],
                    Information = information,
                    Ip = splitted[1],
                    Port = splitted[2],
                    SiteName = splitted[3]
                };
            }
        }
    }
}
