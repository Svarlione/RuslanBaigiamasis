using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CarYearAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int)
            {
                var date = (int)value;
                var minDate = 1886;
                var maxDate = DateTime.Now.Year;
                if (date >= minDate && date <= maxDate)
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Any car was not made in that year");
            }
            return ValidationResult.Success;
        }
    }
}
