namespace PrivateTaskerAPI.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ContactEmail { get; set; }
    }
}
