namespace RuslanAPI.Dtos.UserDto
{
    public class ResponseDto
    {
        public ResponseDto(string status, string message)
        {
            Status = status;
            Message = message;
        }

        public string Status { get; set; }
        public string Message { get; set; }
    }
}
