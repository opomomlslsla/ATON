namespace Application.DTO
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int Gender { get; set; }
    }
}
