using Microsoft.AspNetCore.Mvc;
using RuslanAPI.Core.Models_original;
using RuslanAPI.DataLayer.Repositories;
using RuslanAPI.DTO_original.BookDto;
using RuslanAPI.Services_original;
using System.Net;
using System.Net.Mime;

namespace _2._2012.IntroductionAPI.Controllers.Old
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly IBookRepository _respository;
        private readonly ILogger<BookRepository> _logger;
        private readonly IValidatorBookService _validator;
        private readonly IBookMapper _bookMapper;

        public BooksController(IBookRepository database, ILogger<BookRepository> logger, IValidatorBookService validator, IBookMapper bookMapper)
        {
            _respository = database;
            _logger = logger;
            _validator = validator;
            _bookMapper = bookMapper;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<CreateBookDto>> GetAll()
        {
            var books = _respository.GetAll();
            if (books == null)
            {
                _logger.LogError("All Books were not found in the Database.");
                return NotFound();
            }
            _logger.LogInformation("All books were sent to the API.");
            return Ok(_bookMapper.Map(books));
        }

        [HttpGet("{key}")]
        public ActionResult<CreateBookDto> GetByID(int key)
        {
            var book = _respository.Get(key);
            if (book == null)
            {
                _logger.LogWarning("Key does not exist in the Database.");
                return NotFound();
            }
            _logger.LogInformation("The book was sent to the API.");
            return Ok(_bookMapper.Map(book));
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CreateBookDto req)
        {
            if (!_validator.IsValid(req))
            {
                return BadRequest("Input not valid.");
            }
            var bookModel = _bookMapper.Map(req);
            _respository.Insert(bookModel);
            _logger.LogInformation("New Book was added to the Database.");
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(UpdateBookDto req)
        {
            if (!_validator.IsValid(req))
            {
                return BadRequest("Input not valid.");
            }
            var modelBook = _bookMapper.Map(req);
            var isUpdated = _respository.Update(modelBook);
            if (isUpdated == false)
            {
                _logger.LogWarning("Information was not updated");
                return NotFound("Book was not found");
            }
            _logger.LogInformation("The Book was updated in the Database.");
            return Ok("Book updated.");
        }
        [HttpDelete]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            var result = _respository.Delete(id);
            if (result == false)
            {
                _logger.LogError("The book was not deleted in the Database.");
                return NotFound();
            }
            _logger.LogInformation("The Book was deleted successfully in the Database.");
            return Ok();
        }
        [HttpGet("ExistsBy{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult ExistsByID(int id)
        {
            var result = _respository.Exists(id);
            if (result == false)
            {
                _logger.LogError("The book was not found in the Database.");
                return NotFound();
            }
            _logger.LogInformation("The Book exists in the Database.");
            return Ok();
        }

        [HttpGet("FilterByAuthorTitleCover{parameter}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<FilterBookRequestDto>> Filter(string parameter)
        {
            var filteredBooks = _respository.Filter(parameter);
            if (filteredBooks == null)
            {
                _logger.LogError("The filtering did not secceed.");
                return NotFound();
            }
            var result = filteredBooks.Select(b => new FilterBookRequestDto(b)).ToList();
            _logger.LogInformation("The Books were filtered successfully.");
            return Ok(result);
        }


        //[Route("list10")]
        //[HttpGet] //api/Book/{list}
        //public IEnumerable<Book> GetAll()
        //{
        //    var database = new BookInMemory();
        //    var data = database.GetAll().Where(b => b.Id < 11);
        //    return data;
        //}

        //[HttpGet("{id}")] //api/Book/{id}
        //public Book GetOneById(int id)
        //{
        //    var database = new BookInMemory();
        //    var data = database.GetAll().Find(b => b.Id == id);
        //    return data;
        //}

        //[HttpGet("{pageNum}/{pageSize}")] //api/Book/{pageNum}/{pageSize}
        //public IEnumerable<Book> GetPageOfBooks(int pageNum, int pageSize)
        //{
        //    var database = new BookInMemory();
        //    IEnumerable<Book> data;
        //    if (pageNum <= 0)
        //    {
        //        data = null;
        //    }
        //    else
        //    {
        //        data = database.GetAll().Skip((pageNum - 1) * pageSize).Take(pageSize);
        //    }
        //    return data;
        //    //return database.GetAll().Skip((pageNum - 1) * pageSize).Take(pageSize);
        //}

        //[HttpGet("sortedList")] //api/Book/sortedList
        //public IEnumerable<Book> GetPageOfBooks()
        //{
        //    var database = new BookInMemory();
        //    var pageSize = 10;
        //    var data = database.GetAll().OrderBy(b => b.Title);
        //    return data;
        //}

        //[HttpGet("filterByTitleOrAuthor/{para}")] //api/Book/sortedList
        //public IEnumerable<Book> GetBooksByAuthorOrTitle(string para)
        //{
        //    var database = new BookInMemory();
        //    var data = database.GetAll().Where(b => b.Title.StartsWith(para, StringComparison.OrdinalIgnoreCase));
        //    if (data.Count() < 1)
        //    {
        //        data = database.GetAll().Where(b => b.Author.StartsWith(para, StringComparison.OrdinalIgnoreCase));
        //    }
        //    return data;
        //}
        //[HttpPost]
        //public void CreateBook(Book book)
        //{
        //    var database = new BookInMemory();
        //    database.InsertBook(book);
        //}

        //[HttpPut]
        //public void UpdateBook(Book book)
        //{
        //    var database = new BookInMemory();
        //    database.UpdateBook(book);
        //}
        //[HttpDelete("{id}")]
        //public void DeleteBook(int id)
        //{
        //    var database = new BookInMemory();
        //    database.DeleteBook(id);
        //}
    }
}
