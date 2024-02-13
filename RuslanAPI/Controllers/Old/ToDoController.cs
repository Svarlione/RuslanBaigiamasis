using Microsoft.AspNetCore.Mvc;
using RuslanAPI.DataLayer.Repositories;
using RuslanAPI.DTO_original.ToDoDto;
using RuslanAPI.Dtos;
using RuslanAPI.Services_original;
using System.Net.Mime;

namespace _2._2012.IntroductionAPI.Controllers.Old
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        public readonly ITodoRepository _respository;
        public readonly IToDoEmailService _emailService;

        public ToDoController(ITodoRepository database, IToDoEmailService emailService)
        {
            _respository = database;
            _emailService = emailService;
        }

        /// <summary>
        /// Grazina visus todo irasus
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<GetTodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            var data = _respository.GetAll();
            return Ok(data.Select(t => new GetTodoItemDto(t)));
        }

        /// <summary>
        /// Grazina Irasa pagal nurodyta Id numeri
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("{key}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<GetTodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByID(int key)
        {
            var data = _respository.GetByID(key);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(new GetTodoItemDto(data));
        }


        /// <summary>
        /// Iraso nauja ToDo irasa i duomenu baze ir issiuncia email apie tai
        /// </summary>
        /// <param name="req">ToDo item objektas</param>
        /// <returns>Grazina naujai sukurto iraso Id</returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CreateToDoItemDto req)
        {
            var model = CreateToDoItemDto.ToModel(req);
            long newId = _respository.Add(model);
            _ = _emailService.TrySendEmail("myemail@mail.lt", model);
            return CreatedAtAction(nameof(GetByID), new { id = newId });
        }


        //front-end (javascript fetch, dirba su DTO) -->
        //controller (gauna dto ir is dto daro modeli) ->
        //repositori(model) ->
        //database




        //[HttpGet("filterBy/{typeName}")]
        //public IEnumerable<TodoItem> GetAllFilteredByType(string typeName)
        //{
        //    var database = new FakeDataBase();
        //    var data = database.GetAll().Where(t => t.Type == typeName);
        //    return data;
        //}

        //[HttpDelete]
        //public void Delete(int id)
        //{
        //    var database = new FakeDataBase();
        //    database.RemoveToDoItem(id);
        //}
        //[HttpPost]
        //public void CreateTodo(TodoItem todo)
        //{
        //    var database = new FakeDataBase();
        //    database.CreateToDoItem(todo);
        //}
        //[HttpPut()]
        //public void UpdateTodo(TodoItem todo)
        //{
        //    var database = new FakeDataBase();
        //    database.UpdateTodo(todo);
        //}

    }
}
