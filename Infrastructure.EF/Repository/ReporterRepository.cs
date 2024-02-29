using Entities;
using Infrastructure.EF.DataBases;

namespace Infrastructure.EF.Repository
{
    public class ReporterRepository
    {
        AppDbContext Context = new AppDbContext();
        public List<Reporter> GetAll() => Context.Reporters.ToList();

        public Reporter GetById(int id)
        {
            return Context.Reporters.Find(id);
        }

        public void Register(Reporter reporter)
        {
            Context.Reporters.Add(reporter);
            Context.SaveChanges();
        }
    }
}