using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.Models
{
    public class Image
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public byte[] ImageBytes { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Size { get; set; }

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
    }
}
