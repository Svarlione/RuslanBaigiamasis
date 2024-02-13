using RuslanAPI.Core.Models_original;

namespace RuslanAPI.Services_original
{
    public class ToDoEmailService : IToDoEmailService
    {
        public bool TrySendEmail(string to, TodoItem model)
        {
            //kazkokia email siuntimo logika
            Console.WriteLine($"El. pastas issiustas {to}");
            return true;
        }
    }
}
