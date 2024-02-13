using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.DTO
{
    public class AdressDto
    {
        [Required(ErrorMessage = "Miestas yra privalomas")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Gatvė yra privaloma")]
        public string Road { get; set; }

        [Required(ErrorMessage = "Namų numeris yra privalomas")]
        public string HomeNumer { get; set; }

        // FlatNumber nėra žymimas kaip privalomas, nes jis yra nullable
        public string? FlatNumber { get; set; }

        [Required(ErrorMessage = "Adreso tipas yra privalomas")]
        public string Type { get; set; }
    }
}
