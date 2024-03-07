using Entities;

namespace Infrastructure.EF.MyClasses
{
    public class CommentDTO
    {
        public string Description { get; set; }
        public int Likes { get; set; }
        public string ReporterName { get; set; }
    }
}
