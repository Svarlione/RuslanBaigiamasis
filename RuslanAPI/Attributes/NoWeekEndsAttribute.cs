using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NoWeekEndsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = value as DateTime?;
            if (date == null)
            {
                return new ValidationResult("Date is not valid");
            }
            if(date.Value.DayOfWeek == DayOfWeek.Sunday || date.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                return new ValidationResult("Date can not be WeekEnd");
            }
            return ValidationResult.Success;
        }
    }
}
