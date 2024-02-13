using Microsoft.AspNetCore.Http;

namespace RuslanAPI.Core.DTO
{
    public class ImageDto
    {
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
