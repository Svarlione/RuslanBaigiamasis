using RuslanAPI.DataLayer.Models;

namespace RuslanAPI.Dtos.BookDto
{
    public class FilterBookRequestDto
    {
        public FilterBookRequestDto()
        {
        }

        public FilterBookRequestDto(Book model)
        {
            Title = model.Title;
            Author = model.Author;
            CoverType = model.CoverType.ToString();
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverType { get; set; }
    }
}
