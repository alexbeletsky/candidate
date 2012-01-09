using System;

namespace Candidate.Core.Configurations.Exceptions
{
    internal class ConfigurationTypeDiffersFromExpected : Exception
    {
        public ConfigurationTypeDiffersFromExpected(Type actual, Type expected) :
            base(string.Format("Configuration type is wrong, actual is {0}, but expected is {1}", actual.Name,
                                    expected.Name))
        {

        }
    }
}