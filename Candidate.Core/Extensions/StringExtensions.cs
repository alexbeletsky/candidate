using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Extensions
{
    public static class StringExtensions
    {
        public static string SubstitutePunctuationWithDashes(this string title)
        {
            var titleWithoutPunctuation = new string(title.Where(c => !Char.IsPunctuation(c)).ToArray());
            return titleWithoutPunctuation.ToLower().Trim().Replace(" ", "-");
        }

        public static string FirstCharIsUpperCase(this string value)
        {
            return string.Format("{0}{1}", char.ToUpper(value.ElementAt(0)), value.Substring(1));
        }
    }
}
