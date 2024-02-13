using System.ComponentModel;

namespace RuslanAPI.Core.Models_original
{
    public enum BookCover
    {
        Hardcover,
        Paperback,
        Ebook
    }
    public class Book
    {

        public Book()
        {
        }

        public Book(int id, BookCover coverType, string title, string author, int publishYear)
        {
            Id = id;
            CoverType = coverType;
            Title = title;
            Author = author;
            PublishYear = publishYear;
        }

        public int Id { get; set; }
        public BookCover CoverType { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
    }
}
