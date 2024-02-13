using RuslanAPI.DataLayer.FakeDatabase;
using RuslanAPI.DataLayer.Models;

namespace RuslanAPI.DataLayer.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username);
        void SaveUser(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppBooksDbContext _userRespo;

        public UserRepository(AppBooksDbContext userRespo)
        {
            _userRespo = userRespo;
        }
        public User GetUser(string username)
        {
            return _userRespo.Users.FirstOrDefault(u => u.Username == username);
        }
        public void SaveUser(User user)
        {
            _userRespo.Users.Add(user);
            _userRespo.SaveChanges();
        }
    }
}
