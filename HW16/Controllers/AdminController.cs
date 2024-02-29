using Entities;
using Infrastructure.EF.DataBases;
using Infrastructure.EF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HW16.Controllers
{
    public class AdminController : Controller
    {
        NewsRepository NewsRepo = new NewsRepository();
        CategoryRepository categoryRepo = new CategoryRepository();
        public IActionResult Index()
        {
            TempData["currentAdmin"] = InMemoryDataBase.OnlineAdmin.FirstName;
            var allNews = NewsRepo.GetActiveNews();
            return View(allNews);
        }

        public IActionResult RecentNews()
        {
            var RecentNews = NewsRepo.GetRecentNews();
            return View(RecentNews);
        }

        public IActionResult NewsDetails(int id)
        {
            var targetNews = NewsRepo.GetById(id);
            if (targetNews != null)
            {
                NewsRepo.AddCount(id);
                return View(targetNews);
            }

            return NotFound();
        }


        public IActionResult ActivateNews(int id)
        {
            var isActive = NewsRepo.Activate(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNews(int id)
        {
            NewsRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult AllCategories()
        {
            //var AllCategories = categoryRepo.GetAll();
            var categories = categoryRepo.GetNewsCountPerCategory();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category NewCategory)
        {
            categoryRepo.Create(NewCategory);
            return RedirectToAction("AllCategories");
        }

        public IActionResult Editcategory(int id)
        {
            var targetCategory = categoryRepo.GetById(id);
            return View(targetCategory);
        }

        [HttpPost]
        public IActionResult Editcategory(Category model)
        {
            var isEdited = categoryRepo.Update(model);
            if (isEdited)
                return RedirectToAction("AllCategories");
            return View(model);
        }
        public IActionResult Deletecategory(int id)
        {
            categoryRepo.Delete(id);
            return RedirectToAction("AllCategories");
        }
    }
}