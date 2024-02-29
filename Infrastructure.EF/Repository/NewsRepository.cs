using Entities;
using Infrastructure.EF.DataBases;
using Infrastructure.EF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Repository
{
    public class NewsRepository
    {
        AppDbContext Context = new AppDbContext();
        public List<News> GetActiveNews() => Context.News
            .Where(x => x.IsActive)
            .Include(x => x.Category)
            .Include(x => x.Reporter).ToList();

        public List<News> GetAll() => Context.News
            .Include(x => x.Category)
            .Include(x => x.Reporter).ToList();

        public List<News> GetRecentNews()
        {
            return Context.News.Where(x => x.IsActive == false)
                .Include(x => x.Category)
                .Include(x => x.Reporter).ToList();
        }

        public News GetById(int id) => Context.News
            .Include(x => x.Category)
            .Include(x => x.Reporter)
            .FirstOrDefault(x => x.Id == id);


        public bool Activate(int id)
        {
            var targetNews = GetById(id);
            if (targetNews != null)
            {
                targetNews.IsActive = true;
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public void AddCount(int id)
        {
            var targetNews = GetById(id);
            targetNews.ViewCount += 1;
            Context.SaveChanges();
        }

        public bool Create(News news, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                UploadFileService uploadService = new UploadFileService();

                var ImageAddress = uploadService.UploadFileAsync(file);
                news.ReporterId = InMemoryDataBase.OnlineReporter.Id;
                news.PictureLocation = ImageAddress;
                Context.News.Add(news);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(News updateModel, IFormFile file)
        {
            var targetNews = GetById(updateModel.Id);

            if (targetNews != null && file != null && file.Length > 0)
            {
                UploadFileService uploadService = new UploadFileService();
                var ImageAddress = uploadService.UploadFileAsync(file);

                targetNews.Title = updateModel.Title;
                targetNews.ShortDescription = updateModel.ShortDescription;
                targetNews.Description = updateModel.Description;
                targetNews.Category = updateModel.Category;
                targetNews.CategoryId = updateModel.CategoryId;
                targetNews.PictureLocation = ImageAddress;
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var targetNews = GetById(id);
            if (targetNews != null)
            {
                Context.News.Remove(targetNews);
                Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}