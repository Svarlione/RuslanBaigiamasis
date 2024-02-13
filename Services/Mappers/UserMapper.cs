using Microsoft.AspNetCore.Http;
using RuslanAPI.Core.DTO;
using RuslanAPI.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RuslanAPI.Services.Mappers
{
    public class UserMapper : IUserMapper
    {
        public User MapToUserEntity(CreateUserDto createUserDto)
        {
            return new User()
            {
                FirstName = createUserDto.FirstName,
                LaststName = createUserDto.LaststName,
                PersonalIndefication = createUserDto.PersonalIndefication,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
                LoginInfo = new LoginInfo()
                {
                    UserName = "",
                    Password = new byte[] { },
                    PasswordSalt = new byte[] { },
                    Role = "user"
                }

            };
        }

        public User MapToUserEntity(UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
            {
                return null;
            }

            return new User()
            {
                Email = updateUserDto.Email,
                PhoneNumber = updateUserDto.PhoneNumber,
                LoginInfo = new LoginInfo()
                {
                    Password = Encoding.UTF8.GetBytes(updateUserDto.Password),
                    //  Encoding.UTF8.GetBytes();
                },
                Adress = MapToUserAdressEntity(updateUserDto.Address),
                Image = MapToImageEntity(updateUserDto.Image)
            };
        }

        public UserAdress MapToUserAdressEntity(AdressDto addressDto)
        {
            if (addressDto == null)
            {
                return null;
            }

            // Проверка обязательных полей
            var context = new ValidationContext(addressDto, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(addressDto, context, results, validateAllProperties: true))
            {
                // Если есть ошибки валидации, вы можете обработать их здесь или выбросить исключение
                throw new ArgumentException("Validation failed for AdressDto", nameof(addressDto));
            }

            return new UserAdress()
            {
                Town = addressDto.Town,
                Road = addressDto.Road,
                HomeNumer = addressDto.HomeNumer,
                FlatNumber = addressDto.FlatNumber,
                Type = addressDto.Type
            };
        }

        public Image MapToImageEntity(ImageDto imageDto)
        {
            if (imageDto == null)
            {
                return null;
            }

            return new Image()
            {
                Name = imageDto.Name,
                Description = imageDto.Description,
                ImageBytes = ConvertToBytes(imageDto.Image)
            };
        }

        public Image MapToImageEntity(ImageUpdateDto imageUpdateDto)
        {
            if (imageUpdateDto == null || imageUpdateDto.Image == null)
            {
                return null;
            }

            byte[] imageBytes;
            using (var stream = new MemoryStream())
            {
                imageUpdateDto.Image.CopyTo(stream);
                imageBytes = stream.ToArray();
            }

            return new Image()
            {
                Name = imageUpdateDto.Name,
                Description = imageUpdateDto.Description,
                ImageBytes = imageBytes
            };
        }
        private byte[] ConvertToBytes(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
