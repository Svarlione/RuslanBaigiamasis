using RuslanAPI.Core.Models_original;

namespace RuslanAPI.DTO_original.BookDto
{
    public class GetBookDto
    {
        public GetBookDto()
        {
        }

        public GetBookDto(Book model)
        {
            Id = model.Id;
            CoverType = model.CoverType.ToString();
            Title = model.Title;
            Author = model.Author;
            PublishYear = model.PublishYear == 0 ? DateTime.MinValue : new DateTime(model.PublishYear, 1, 1);
        }
        public int Id { get; set; }
        public string CoverType { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishYear { get; set; }
    }
}
