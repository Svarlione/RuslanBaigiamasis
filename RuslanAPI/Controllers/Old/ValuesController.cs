using Microsoft.AspNetCore.Mvc;
using RuslanAPI.Services_original;

namespace _2._2012.IntroductionAPI.Controllers.Old
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //static List<string> values = new List<string> { "value1", "value2" };
        public readonly IValueRespository _respository;

        public ValuesController(IValueRespository respository)
        {
            _respository = respository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _respository.GetAll();
        }
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            var valueResult = _respository.Add(value);
            Console.WriteLine("Added value:" + valueResult);
            return Ok();
        }
    }
}
