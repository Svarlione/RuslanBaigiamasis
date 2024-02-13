using RuslanAPI.Core.Models_original;

namespace RuslanAPI.Services_original
{
    public interface IToDoEmailService
    {
        bool TrySendEmail(string to, TodoItem model);
    }
}
