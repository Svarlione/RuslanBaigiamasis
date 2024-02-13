using RuslanAPI.Core.DTO;
using RuslanAPI.Core.Models;

namespace RuslanAPI.Services.Mappers
{
    public interface IUserMapper
    {
        Image MapToImageEntity(ImageDto imageDto);
        Image MapToImageEntity(ImageUpdateDto imageUpdateDto);
        UserAdress MapToUserAdressEntity(AdressDto addressDto);
        User MapToUserEntity(CreateUserDto createUserDto);
        User MapToUserEntity(UpdateUserDto updateUserDto);
    }
}