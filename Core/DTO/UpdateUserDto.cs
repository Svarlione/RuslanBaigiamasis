using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.DTO
{
    public class UpdateUserDto
    {
        [EmailAddress(ErrorMessage = "Netinkamas el. pašto formatas")]
        public string Email { get; set; }

        public AdressDto? Address { get; set; }

        public ImageDto? Image { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "Netinkamas telefono numerio formatas")]
        public string PhoneNumber { get; set; }

        [MinLength(6, ErrorMessage = "Slaptažodis turi turėti bent 6 simbolius")]
        [RegularExpression(".*[A-Z].*", ErrorMessage = "Slaptažodyje turi būti bent viena didžioji raidė")]
        public byte[] Password { get; set; }
    }
}
