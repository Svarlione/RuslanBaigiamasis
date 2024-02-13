using RuslanAPI.Dtos.BookDto;
using RuslanAPI.DataLayer.Models;

namespace RuslanAPI.Services
{
    public class BookMapper : IBookMapper
    {
        public CreateBookDto Map(Book model)
        {
            return new CreateBookDto
            {
                CoverType = model.CoverType.ToString(),
                Title = model.Title,
                Author = model.Author,
                PublishYear = model.PublishYear == 0 ? DateTime.MinValue : new DateTime(model.PublishYear, 1, 1),
            };
        }
        public IEnumerable<CreateBookDto> Map(List<Book> models)
        {
            return models.Select(Map);
        }
        public Book Map(CreateBookDto dto)
        {
            bool isParsedCover = Enum.TryParse(dto.CoverType, out BookCover coverEnumValue);
            return new Book
            {
                CoverType = coverEnumValue,
                Title = dto.Title,
                Author = dto.Author,
                PublishYear = (int)dto.PublishYear?.Year,
            };
        }
        public Book Map(UpdateBookDto dto)
        {
            bool isParsedCover = Enum.TryParse(dto.CoverType, out BookCover coverEnumValue);
            return new Book
            {
                Id = dto.Id,
                CoverType = coverEnumValue,
                Title = dto.Title,
                Author = dto.Author,
                PublishYear = dto.PublishYear.Year,
            };
        }
    }

    public interface IBookMapper
    {
        CreateBookDto Map(Book model);
        IEnumerable<CreateBookDto> Map(List<Book> models);
        Book Map(CreateBookDto dto);
        Book Map(UpdateBookDto dto);
    }
}
