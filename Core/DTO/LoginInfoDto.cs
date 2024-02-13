using RuslanAPI.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.DTO
{
    public class LoginInfoDto
    {
        [Required(ErrorMessage = "Vartotojo vardas yra privalomas")]
        [MinLength(4, ErrorMessage = "Vartotojo vardas turi turėti bent 4 simbolius")]
        [RegularExpression("^[a-z]+$", ErrorMessage = "Vartotojo vardas turi būti tik iš mažųjų raidžių")]
        [UniqueUserName(ErrorMessage = "Tokiu vartotojo vardu jau yra registruotas")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Slaptažodis yra privalomas")]
        [MinLength(6, ErrorMessage = "Slaptažodis turi turėti bent 6 simbolius")]
        [RegularExpression(".*[A-Z].*", ErrorMessage = "Slaptažodyje turi būti bent viena didžioji raidė")]
        public string Password { get; set; }




    }
}
