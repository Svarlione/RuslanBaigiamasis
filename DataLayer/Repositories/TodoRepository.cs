using RuslanAPI.Core.Models_original;
using RuslanAPI.DataLayer.FakeDatabase;

namespace RuslanAPI.DataLayer.Repositories
{
    public interface ITodoRepository
    {
        long Add(TodoItem item);
        void Delete(int key);
        List<TodoItem> GetAll();
        TodoItem GetByID(int key);
        void Update(TodoItem item);
    }

    public class TodoRepository : ITodoRepository
    {
        private static List<TodoItem> _database;

        public TodoRepository()
        {
            _database = new TodoFakeDataBase().GetAll();
        }
        public List<TodoItem> GetAll()
        {
            return _database;
        }
        public TodoItem GetByID(int key)
        {
            return _database.Find(t => t.Id == key);
        }
        public long Add(TodoItem item)
        {
            var newId = _database.Max(t => t.Id) +1;
            item.Id = newId;
            _database.Add(item);
            return newId;
        }
        public void Update(TodoItem item)
        {
            var index = _database.FindIndex(t=>t.Id == item.Id);
            _database[index]= item;
        }
        public void Delete(int key)
        {
            var index = _database.FindIndex(t => t.Id == key);
            _database.RemoveAt(index);
        }

 

    }
}
