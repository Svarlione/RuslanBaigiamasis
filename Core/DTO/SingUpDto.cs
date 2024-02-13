using RuslanAPI.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RuslanAPI.Core.DTO
{
    public class SingUpDto
    {
        [Required(ErrorMessage = "Имя пользователя обязательно")]
        [MinLength(4, ErrorMessage = "Имя пользователя должно содержать не менее 4 символов")]
        [RegularExpression("^[a-z]+$", ErrorMessage = "Имя пользователя должно содержать только строчные буквы")]
        [UniqueUserName(ErrorMessage = "Пользователь с таким именем уже зарегистрирован")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        [RegularExpression(".*[A-Z].*", ErrorMessage = "Пароль должен содержать хотя бы одну заглавную букву")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Роль обязательна")]
        public string Role { get; set; } = "user";
    }
}
