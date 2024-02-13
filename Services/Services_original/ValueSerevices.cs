namespace RuslanAPI.Services_original
{
    public class ValueSerevices : IValueRespository
    {

        public List<string> Values { get; set; } = new List<string> { "value1", "value2" };


        public List<string> GetAll()
        {
            return Values;
        }

        public string Add(string value)
        {
            Values.Add(value);
            return value;
        }
    }

    public interface IValueRespository
    {
        string Add(string value);
        List<string> GetAll();
    }
}
