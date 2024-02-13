using RuslanAPI.Core.Models_original;
using RuslanAPI.DataLayer.Repositories;
using RuslanAPI.DTO_original.VartotojasDto;
using System.Security.Cryptography;

namespace RuslanAPI.Services_original
{
    public interface IVartotojasServices
    {
        ResponseDto Login(string username, string password, out string role);
        ResponseDto Signup(string username, string password);
    }

    public class VartotojasServices : IVartotojasServices
    {
        private readonly IVartotojasRepository _userRepository;

        public VartotojasServices(IVartotojasRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ResponseDto Login(string username, string password, out string role)
        {
            var user = _userRepository.GetUser(username);
            role = user.Role;
            if (user is null)
                return new ResponseDto("Fail", "Username does not match");

            if (!VerifyPasswordHash(password, user.Password, user.PasswordSalt))
                return new ResponseDto("Fail", "Password does not match");

            return new ResponseDto("Success", "User logged in");
        }

        public ResponseDto Signup(string username, string password)
        {
            var user = _userRepository.GetUser(username);
            if (user is not null)
                return new ResponseDto("Fail", "User already exists");

            user = CreateUser(username, password);
            _userRepository.SaveUser(user);
            return new ResponseDto("Success", "User created");
        }

        private Vartotojas CreateUser(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new Vartotojas
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "User"
            };

            return user;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
