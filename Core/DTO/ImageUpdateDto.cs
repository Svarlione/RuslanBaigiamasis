using Microsoft.AspNetCore.Http;

namespace RuslanAPI.Core.DTO
{
    public class ImageUpdateDto
    {
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
