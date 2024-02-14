
namespace RuslanAPI.Services.Authorization
{
    public interface IAuthService
    {
        byte[] GeneratePasswordSalt();
        Task<string> LoginAsync(string userName, string password);
        Task<string> SignUpAsync(string username, string role, string password, byte[] passwordSalt, string personalIndefication, string email);
    }
}