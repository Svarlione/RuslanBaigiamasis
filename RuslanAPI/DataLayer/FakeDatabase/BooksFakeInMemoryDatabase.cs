using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using System;
using RuslanAPI.DataLayer.Models;


namespace RuslanAPI.DataBase
{
    public class BooksFakeInMemoryDatabase
    {
        private static List<Book> booksList = new List<Book> 
        {
            new Book (1, BookCover.Paperback, "The Midnight Library","Matt Haig",1987),
            new Book (2, BookCover.Hardcover, "The Invisible Life of Addie LaRue","V.E. Schwab", 2000),
            new Book (3, BookCover.Hardcover, "The Seven Husbands of Evelyn Hugo","Taylor Jenkins Reid", 2003),
            new Book (4, BookCover.Ebook, "Becoming","Michelle Obama", 2020),
            new Book (5, BookCover.Hardcover,"Educated","Tara Westover", 1999),
            new Book (6, BookCover.Paperback, "Circe","Madeline Miller", 2010),
            new Book (7, BookCover.Paperback, "Where the Crawdads Sing","Delia Owens", 1947),
            new Book (8, BookCover.Hardcover, "The Victory Garden","Rhys Bowen", 1989),
            new Book (9, BookCover.Paperback, "An Anonymous Girl","Greer Hendricks and Sarah Pekkanen", 1990),
            new Book (10, BookCover.Hardcover, "Iron Flame","Rebecca Yarros", 2013),
            new Book (11, BookCover.Ebook, "The Empyrean","Rebecca Yarros", 2015),
            new Book (12, BookCover.Paperback, "The Last Letter","Rebecca Yarros", 2009),
            new Book (13, BookCover.Ebook, "The Four Winds","Kristin Hannah", 2020),
            new Book (14, BookCover.Paperback, "The Sanatorium","Sarah Pearse", 2014),
            new Book (15, BookCover.Hardcover, "The Rose Code","Kate Quinn",1966),
        };

        public List<Book> GetAll()
        {
            return booksList;
        }
        //public void InsertBook(Book book)
        //{
        //    booksList.Add(book);
        //}
        //public void UpdateBook(Book book)
        //{
        //    var bookFromDb = booksList.FirstOrDefault(b => b.Id == book.Id);
        //    if(bookFromDb == null)
        //    {
        //        throw new ArgumentException($"Book with ID {book.Id} was not found in database");
        //    }
        //    if(!string.IsNullOrEmpty(book.Author))
        //    {
        //        bookFromDb.Author = book.Author;
        //    }
        //    if (!string.IsNullOrEmpty(book.Author))
        //    {
        //        bookFromDb.Title = book.Title;
        //    }
        //    //context.SaveChanges();
        //}
        //public void DeleteBook(int id)
        //{
        //    booksList.Remove(booksList.FirstOrDefault(b => b.Id == id));
        //    //context.SaveChanges();
        //}
    }
}
