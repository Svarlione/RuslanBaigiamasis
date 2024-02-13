using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RuslanAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

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

                var token = GenerateJwtToken(user.LoginInfo);

                return token;
            }
            catch (Exception ex)
            {
                // Логируйте ошибку для последующего анализа
                Console.WriteLine($"Error during login: {ex}");
                throw; // Перевыбрасывайте исключение, чтобы обработка ошибок на уровне выше могла обработать их
            }
        }

        public async Task<string> SignUpAsync(string username, string role, string password)
        {
            try
            {
                var loginInfo = new LoginInfo
                {
                    UserName = username,
                    Password = HashPassword(password),
                    Role = role
                };

                // Ваши дополнительные действия при регистрации, например, сохранение в базу данных

                var token = GenerateJwtToken(loginInfo);

                return token;
            }
            catch (Exception ex)
            {
                // Логируйте ошибку для последующего анализа
                Console.WriteLine($"Error during sign up: {ex}");
                throw; // Перевыбрасывайте исключение, чтобы обработка ошибок на уровне выше могла обработать их
            }
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

        private string GenerateJwtToken(LoginInfo loginInfo)
        {
            // Ваши текущие действия по генерации токена JWT
            // ...

            return "your_generated_token_here";
        }

        private async Task<User> FindUserByNameAsync(string userName)
        {
            // Ваши текущие действия по поиску пользователя
            // ...

            return new User { LoginInfo = new LoginInfo { UserName = userName } };
        }
    }

}
