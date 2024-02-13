using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuslanAPI.Core.Models
{
    public class UserAdress
    {
        [Key]
        public long Id { get; set; }
        public string Town { get; set; } = string.Empty;
        public string Road { get; set; } = string.Empty;
        public string HomeNumer { get; set; } = string.Empty;
        public string? FlatNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; //home, work, hollyday

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
    }
}
