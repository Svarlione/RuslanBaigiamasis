using RuslanAPI.Core.Models;
using Image = RuslanAPI.Core.Models.Image;

namespace RuslanAPI.DataLayer.Data
{
    public interface IDbRepository
    {
        long Create(User user);
        void CreateAdress(UserAdress userAdress);
        void CreatImage(Image image);
        void DeleteUser(long userId);
        User GetUserByUserId(long userId);
        void UpdateAdress(UserAdress userAdress);
        void UpdateImage(Image image);
        void UpdateUser(User user);
    }
}