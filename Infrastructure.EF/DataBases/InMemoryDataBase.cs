using Entities;

namespace Infrastructure.EF.DataBases
{
    public static class InMemoryDataBase
    {
        public static Reporter? OnlineReporter { get; set; }
        public static Admin? OnlineAdmin { get; set; }
    }
}
