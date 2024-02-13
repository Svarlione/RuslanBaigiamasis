using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.Models_original
{
    public class Image
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public byte[] ImageBytes { get; set; } = null!;

        [ForeignKey(nameof(Vartotojas))]
        public long UserId { get; set; }
    }
}
