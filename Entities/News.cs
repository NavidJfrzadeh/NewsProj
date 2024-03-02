namespace Entities
{
    public class News
    {
        public News()
        {
            IsActive = false;
        }
        public int Id { get; set; }
        public string PictureLocation { get; set; }
        public string PictureAlt { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ReporterId { get; set; }
        public Reporter Reporter { get; set; }
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public bool IsActive { get; set; }
    }
}
