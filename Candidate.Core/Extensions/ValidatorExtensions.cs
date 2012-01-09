using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Extensions
{
    public static class ValidatorExtensions
    {
        public static bool TryValidateObject(this object validate)
        {
            return Validator.TryValidateObject(validate, new ValidationContext(validate, null, null), null);
        }
    }
}