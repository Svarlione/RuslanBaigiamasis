using RuslanAPI.Core.Attributes_original;
using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.DTO_original.CarDto
{
    public class CreateCarDto
    {
        /// <summary>
        /// The brand which was car made under
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Make { get; set; }
        /// <summary>
        /// Car specific model name assigned by namufacturer
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Model { get; set; }
        /// <summary>
        /// Car make year
        /// </summary>
        [Required]
        [CarYear]        
        public int Year { get; set; }
        /// <summary>
        /// License plate number given when car was registred by legal offices
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*\d)[a-zA-Z\d]{6}$", ErrorMessage = "License plate must consist of 6 characters and at least 1 digit")]
        public string LicensePlate { get; set; }
        /// <summary>
        /// Overall Car driven distance
        /// </summary>
        [Range(0, 1000000)]
        public double Mileage { get; set; }
        /// <summary>
        /// Car body Type
        /// </summary>
        [CarType]
        public string Type { get; set; }
        /// <summary>
        /// Car image URL address
        /// </summary>
        //[CarImageUrl]
        [Url]
        public string ImageUrl { get; set; }
    }
}
