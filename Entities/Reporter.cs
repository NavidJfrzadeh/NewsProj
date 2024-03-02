namespace Entities
{
    public class Reporter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<News>? News { get; set; } = new List<News>();
        public List<Comment>? Comments { get; set; } = new List<Comment>();
    }
}
