using System.Net.Http.Headers;

namespace Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<News>? News { get; set; }
    }
}