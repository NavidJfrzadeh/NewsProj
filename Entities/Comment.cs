namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int ReporterId { get; set; }
        public Reporter Reporter { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}