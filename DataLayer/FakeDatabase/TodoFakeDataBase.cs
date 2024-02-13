using RuslanAPI.Core.Models_original;

namespace RuslanAPI.DataLayer.FakeDatabase
{
    public class TodoFakeDataBase
    {
        private static List<TodoItem> todoList = new List<TodoItem>
        {
            new TodoItem(1, "Work", "Complete assignment", DateTime.Parse("2024-01-10"), "user4"),
            new TodoItem(2, "Work", "Visit doctor", DateTime.Parse("2024-01-12"), "user2"),
            new TodoItem(3, "Other", "Buy groceries", DateTime.Parse("2023-12-20"), "user2"),
            new TodoItem(4, "Work", "Visit doctor", DateTime.Parse("2023-12-31"), "user5"),
            new TodoItem(5, "Work", "Visit doctor", DateTime.Parse("2023-12-23"), "user2"),
            new TodoItem(6, "Other", "Visit doctor", DateTime.Parse("2023-12-26"), "user4"),
            new TodoItem(7, "Work", "Call plumber", DateTime.Parse("2023-12-28"), "user4"),
            new TodoItem(8, "Shopping", "Attend webinar", DateTime.Parse("2023-12-31"), "user8"),
            new TodoItem(9, "Work", "Visit doctor", DateTime.Parse("2023-12-26"), "user1"),
            new TodoItem(10, "Other", "Attend webinar", DateTime.Parse("2023-12-31"), "user8"),
            new TodoItem(11, "Shopping", "Plan vacation", DateTime.Parse("2024-01-08"), "user3"),
            new TodoItem(12, "Shopping", "Complete assignment", DateTime.Parse("2023-12-24"), "user9"),
            new TodoItem(13, "Shopping", "Call plumber", DateTime.Parse("2023-12-31"), "user1"),
            new TodoItem(14, "Work", "Call plumber", DateTime.Parse("2024-01-06"), "user4"),
            new TodoItem(15, "Work", "Call plumber", DateTime.Parse("2023-12-27"), "user3")
        };
        public List<TodoItem> GetAll()
        {
            return todoList;
        }
        public void RemoveToDoItem(int id)
        {
            todoList.Remove(todoList.FirstOrDefault(t => t.Id == id));
            //context.SaveChanges();
        }
        public void CreateToDoItem(TodoItem todo)
        {
            todoList.Add(todo);
            //context.SaveChanges();
        }
        public void UpdateTodo(TodoItem todo)
        {
            var todoItemDb = todoList.FirstOrDefault(t => t.Id == todo.Id);
            if (todoItemDb == null)
            {
                throw new ArgumentException($"ToDo Item with ID {todo.Id} was not found in database");
            }
            if (!string.IsNullOrEmpty(todo.Type))
            {
                todoItemDb.Type = todo.Type;
            }
            if (!string.IsNullOrEmpty(todo.Content))
            {
                todoItemDb.Content = todo.Content;
            }
            if (!string.IsNullOrEmpty(todo.UserId))
            {
                todoItemDb.UserId = todo.UserId;
            }
            todoItemDb.EndDate = todo.EndDate;

            //context.SaveChanges();
        }
    }
}

