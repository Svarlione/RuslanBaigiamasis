using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using System;
using RuslanAPI.DataLayer.Models;

namespace RuslanAPI.DataBase
{
    public class BookInMemory
    {
    //    private static List<Book> booksList = new List<Book> 
    //    {
    //        new Book (1, "The Midnight Library","Matt Haig"),
    //        new Book (2, "The Invisible Life of Addie LaRue","V.E. Schwab"),
    //        new Book (3, "The Seven Husbands of Evelyn Hugo”","Taylor Jenkins Reid"),
    //        new Book (4, "Becoming","Michelle Obama"),
    //        new Book (5, "Educated","Tara Westover"),
    //        new Book (6, "Circe","Madeline Miller"),
    //        new Book (7, "Where the Crawdads Sing","Delia Owens"),
    //        new Book (8, "The Victory Garden","Rhys Bowen"),
    //        new Book (9, "An Anonymous Girl","Greer Hendricks and Sarah Pekkanen"),
    //        new Book (10, "Iron Flame","Rebecca Yarros"),
    //        new Book (11, "The Empyrean","Rebecca Yarros"),
    //        new Book (12, "The Push","Ashley Audrain"),
    //        new Book (13, "The Four Winds","Kristin Hannah"),
    //        new Book (14, "The Sanatorium","Sarah Pearse"),
    //        new Book (15, "The Rose Code","Kate Quinn"),
    //    };
    //    public List<Book> GetAll()
    //    {
    //        return booksList;
    //    }
    //    public void InsertBook(Book book)
    //    {
    //        booksList.Add(book);
    //    }
    //    public void UpdateBook(Book book)
    //    {
    //        var bookFromDb = booksList.FirstOrDefault(b => b.Id == book.Id);
    //        if(bookFromDb == null)
    //        {
    //            throw new ArgumentException($"Book with ID {book.Id} was not found in database");
    //        }
    //        if(!string.IsNullOrEmpty(book.Author))
    //        {
    //            bookFromDb.Author = book.Author;
    //        }
    //        if (!string.IsNullOrEmpty(book.Author))
    //        {
    //            bookFromDb.Title = book.Title;
    //        }
    //        //context.SaveChanges();
    //    }
    //    public void DeleteBook(int id)
    //    {
    //        booksList.Remove(booksList.FirstOrDefault(b => b.Id == id));
    //        //context.SaveChanges();
    //    }
    }
}
