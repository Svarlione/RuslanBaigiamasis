using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.Models
{
    public class LoginInfo
    {
        [Key]
        public long Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public byte[] Password { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string Role { get; set; } = "user";

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }

    }
}
