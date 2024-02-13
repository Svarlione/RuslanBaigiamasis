using Microsoft.EntityFrameworkCore;
using RuslanAPI.Core.Models_original;
using RuslanAPI.DataLayer.FakeDatabase;

namespace RuslanAPI.DataLayer.Repositories
{
    public interface IBookRepository
    {
        long Insert(Book item);
        public List<Book> GetAll();
        public Book Get(int key);
        List<Book> Filter(string parameter);
        bool Exists(int id);
        bool Update(Book req);
        bool Delete(int id);
    }

    public class BookRepository : IBookRepository
    {

        private readonly AppBooksDbContext _appBooksDbContext;


        public BookRepository(AppBooksDbContext applicationDbContext)
        {
            _appBooksDbContext = applicationDbContext;
        }

        public List<Book> GetAll()
        {
            var modelBooks = _appBooksDbContext.Books.ToList();
            return modelBooks;
        }
        public Book Get(int key)
        {
            var bookByID = _appBooksDbContext.Books.FirstOrDefault(x => x.Id == key);
            return bookByID;
            //if(bookByID == null)
            //{

            //    return new Book();
            //}
            //else
            //{
            //    return bookByID;
            //}
        }
        public long Insert(Book req)
        {
            _appBooksDbContext.Books.Add(req);
            _appBooksDbContext.SaveChanges();
            var bookByTitle = _appBooksDbContext.Books.FirstOrDefault(x => x.Title == req.Title);
            return bookByTitle.Id;
        }
        public bool Update(Book model)
        {
            var bookFromDb = _appBooksDbContext.Books.FirstOrDefault(t=>t.Id == model.Id);
            if(bookFromDb !=null)
            {
                bookFromDb.CoverType = model.CoverType;
                bookFromDb.Title = model.Title;
                bookFromDb.Author = model.Author;
                bookFromDb.PublishYear = model.PublishYear;
                _appBooksDbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }
        public bool Delete(int id)
        {
            var bookFromDb = _appBooksDbContext.Books.FirstOrDefault(t => t.Id == id);
            if (bookFromDb != null)
            {
                _appBooksDbContext.Books.Remove(bookFromDb);
                _appBooksDbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }
        public bool Exists(int id)
        {
            var bookFromDb = _appBooksDbContext.Books.FirstOrDefault(t => t.Id == id);
            if(bookFromDb != null)
            {
                return true;
            }
            else { return false; }
        }
        public List<Book> Filter(string parameter)
        {
            var books = _appBooksDbContext.Books; ///Select(b => new FilterBookRequestDto(b));
            var byAuthor = books.Where(b => EF.Functions.Like(b.Author,$"{parameter}%")).ToList();
            var byTitle = books.Where(b => EF.Functions.Like(b.Title, $"{parameter}%")).ToList();
            if (byAuthor.Count() > 0)
            {
                return byAuthor;
            }
            else if (byTitle.Count() > 0)
            {
                return byTitle;
            }
            //else if (byCover.Count()>0)
            //{
            //    return byCover;
            //}
            else
            {
                return null;
            }
        }
    }
}
