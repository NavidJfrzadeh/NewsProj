namespace Infrastructure.EF.MyClasses
{
    public class NewsDTO
    {
        public string PictureLocation { get; set; }
        public string PictureAlt { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CategoryTitle { get; set; }
        public string ReporterName { get; set; }
        public List<CommentDTO>? Comments { get; set; } = new List<CommentDTO>();
    }
}
