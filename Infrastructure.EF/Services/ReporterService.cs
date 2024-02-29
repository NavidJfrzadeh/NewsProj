using Entities;
using Infrastructure.EF.Repository;

namespace Infrastructure.EF.Services
{
    public class ReporterService
    {
        ReporterRepository ReporterRepo = new ReporterRepository();
        NewsRepository NewsRepo = new NewsRepository();
        public Reporter CheckLogin(string email, string password)
        {
            var Reporters = ReporterRepo.GetAll();
            return Reporters.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public bool AddReporter(Reporter newReporter)
        {
            ReporterRepo.Register(newReporter);
            return true;
        }

        public List<News> ReporterNews(int reporterId)
        {
            var ReporterNews = NewsRepo.GetAll().Where(e => e.ReporterId == reporterId).ToList();
            return ReporterNews;

        }
    }
}
