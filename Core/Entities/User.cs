using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LaststName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PersonalIndefication { get; set; }
        public string Email { get; set; } = string.Empty;

        [Required]
        public UserAdress Adress { get; set; }

        [Required]
        public LoginInfo LoginInfo { get; set; }

        [Required]
        public Image Image { get; set; }
    }
}
