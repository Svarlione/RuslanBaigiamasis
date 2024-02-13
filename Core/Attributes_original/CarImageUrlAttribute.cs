using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.Attributes_original
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CarImageUrlAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var type = value as string;
            if (type == null && type.Length < 12)
            {
                return false;
            }
            Uri uriResult;
            var isValidUrl = Uri.TryCreate(type, UriKind.Absolute, out uriResult);
            return isValidUrl;
        }
    }
}
