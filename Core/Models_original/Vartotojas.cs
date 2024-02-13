namespace RuslanAPI.Core.Models_original
{
    public class Vartotojas
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
