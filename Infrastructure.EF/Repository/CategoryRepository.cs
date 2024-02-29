using Entities;
using HW16.Models;
using Infrastructure.EF.DataBases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Repository
{
    public class CategoryRepository
    {
        AppDbContext Context = new AppDbContext();

        public List<Category> GetAll() => Context.Categories.ToList();

        public Category GetById(int id) => Context.Categories.Find(id);

        public List<CategoryNews> GetNewsCountPerCategory()
        {
            var categoryNewsCounts = Context.Categories
                .Select(c => new CategoryNews
                {
                    catId = c.Id,
                    CategoryTitle = c.Title,
                    NewsCount = c.News.Count()
                });

            var query = categoryNewsCounts.ToQueryString();
            return categoryNewsCounts.ToList();
        }

        public bool Create(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
            return true;
        }

        public bool Update(Category category)
        {
            var targetCategory = GetById(category.Id);
            targetCategory.Title = category.Title;
            Context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var category = GetById(id);
            Context.Categories.Remove(category);
            Context.SaveChanges();
            return true;
        }
    }
}