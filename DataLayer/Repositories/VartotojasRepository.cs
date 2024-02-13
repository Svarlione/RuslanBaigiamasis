using RuslanAPI.Core.Models_original;
using RuslanAPI.DataLayer.FakeDatabase;


namespace RuslanAPI.DataLayer.Repositories
{
    public interface IVartotojasRepository
    {
        Vartotojas GetUser(string username);
        void SaveUser(Vartotojas user);
    }

    public class VartotojasRepository : IVartotojasRepository
    {
        private readonly AppBooksDbContext _userRespo;

        public VartotojasRepository(AppBooksDbContext userRespo)
        {
            _userRespo = userRespo;
        }
        public Vartotojas GetUser(string username)
        {
            return _userRespo.Users.FirstOrDefault(u => u.Username == username);
        }
        public void SaveUser(Vartotojas user)
        {
            _userRespo.Users.Add(user);
            _userRespo.SaveChanges();
        }
    }
}
