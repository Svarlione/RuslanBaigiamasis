namespace RuslanAPI.DataLayer.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
        }
        public TodoItem(long id, string type, string content, DateTime? endDate, string userId)
        {
            Content = content;
            Id = id;
            Type = type;
            EndDate = endDate;
            UserId = userId;
        }

        public long Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserId { get; set; }
    }
}
