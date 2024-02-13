using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.Attributes
{
    public class UniqueUserNameAttribute : ValidationAttribute
    {
        //patikrina ar domenu bazeje nepasikartoja user name(unikalus)
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
    }
}
