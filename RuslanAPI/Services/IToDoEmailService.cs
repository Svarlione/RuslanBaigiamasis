using RuslanAPI.DataLayer.Models;

namespace RuslanAPI.Services
{
    public interface IToDoEmailService
    {
        bool TrySendEmail(string to, TodoItem model);
    }
}
