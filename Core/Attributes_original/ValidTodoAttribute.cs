using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.Attributes_original
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidTodoTypeAttribute : ValidationAttribute
    {

        //private readonly string[] _validTypes = {"work", "Home", }
        private readonly string[] validTypes = new string[] { "work", "home", "other" };

        public override bool IsValid(object? value)
        {
            var type = value as string;
            if(type == null)
            {
                return false;
            }
            var isValid = validTypes.Contains(type.ToLower());
            return isValid;
        }
    }
}
