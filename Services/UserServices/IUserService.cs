using RuslanAPI.Core.DTO;
using RuslanAPI.Core.Models;

namespace RuslanAPI.Services.UserServices
{
    public interface IUserService
    {
        void CreateImage(ImageDto imageDto, long userid);
        long CreateUser(CreateUserDto createUserDto);
        void CreateUserAddress(UserAdress userAddress, long userid);
        void DeleteUser(long userId);
        User GetUserByUserId(long userId);
        void UpdateImage(ImageUpdateDto imageUpdateDto, long userid);
        void UpdateUser(UpdateUserDto updateUserDto, long userId);
        void UpdateUserAddress(UserAdress userAddress, long userid);
    }
}