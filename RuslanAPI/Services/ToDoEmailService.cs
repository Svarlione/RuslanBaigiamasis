using RuslanAPI.DataLayer.Models;

namespace RuslanAPI.Services
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
