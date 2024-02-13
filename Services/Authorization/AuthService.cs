using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RuslanAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Security.Cryptography;

namespace RuslanAPI.Services.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            try
            {
                var user = await FindUserByNameAsync(userName);

                if (user == null || !VerifyPassword(user.LoginInfo, password))
                {
                    throw new InvalidOperationException("Invalid username or password.");
                }
                var role = "user";
                var token = GenerateJwtToken(user.LoginInfo.UserName, role, user.Id);


                return token;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error during login: {ex}");
                throw;
            }
        }

        public async Task<string> SignUpAsync(string username, string role, string password, byte[] passwordSalt)
        {
            try
            {
                var loginInfo = new LoginInfo
                {
                    UserName = username,
                    Password = HashPassword(password),
                    PasswordSalt = passwordSalt,
                    Role = role
                };
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error during sign up: {ex}");
                throw;
            }
            return await SignUpAsync(username, role, password, passwordSalt);
        }

        private byte[] HashPassword(string password)
        {
            return Encoding.UTF8.GetBytes(_passwordHasher.HashPassword(null, password));
        }

        private bool VerifyPassword(LoginInfo loginInfo, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, Convert.ToBase64String(loginInfo.Password), password);
            return result == PasswordVerificationResult.Success;
        }

        private string GenerateJwtToken(string username, string role, long loginInfoId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, loginInfoId.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var secretKey = _configuration.GetSection("Jwt:Key").Value;
            var issuer = _configuration.GetSection("Jwt:Issuer").Value;
            var audience = _configuration.GetSection("Jwt:Audience").Value;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> FindUserByNameAsync(string userName)
        {


            return new User { LoginInfo = new LoginInfo { UserName = userName } };
        }

        public byte[] GeneratePasswordSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }

}
