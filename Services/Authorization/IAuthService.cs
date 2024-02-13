
namespace RuslanAPI.Services.Authorization
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string userName, string password);
        Task<string> SignUpAsync(string username, string role, string password);
    }
}