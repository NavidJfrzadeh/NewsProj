using Entities;
using Infrastructure.EF.DataBases;
using Infrastructure.EF.Repository;
using Infrastructure.EF.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HW16.Controllers
{
    public class ReporterController : Controller
    {
        ReporterService ReporterService = new ReporterService();
        NewsRepository NewsRepo = new NewsRepository();
        public IFormFile MyFile { get; set; }

        public IActionResult Index()
        {
            TempData["currentReporter"] = InMemoryDataBase.OnlineReporter.FirstName;
            var reporterNews = ReporterService.ReporterNews(InMemoryDataBase.OnlineReporter.Id);
            return View(reporterNews);
        }

        public IActionResult AllNews()
        {
            var ActiveNews = NewsRepo.GetActiveNews();
            return View(ActiveNews);
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

        public IActionResult AddNews()
        {
            ViewBag.IfromFIle = MyFile;
            CategoryRepository categoryRepo = new CategoryRepository();
            ViewBag.Categories = categoryRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddNews(News newNews, IFormFile file)
        {
            var isCreated = NewsRepo.Create(newNews, file);
            if (isCreated is false)
            {
                return View(newNews);
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditNews(int id)
        {
            ViewBag.IfromFIle = MyFile;
            CategoryRepository categoryRepo = new CategoryRepository();
            var targetNews = NewsRepo.GetById(id);
            ViewBag.Categories = categoryRepo.GetAll();
            return View(targetNews);
        }

        [HttpPost]
        public IActionResult EditNews(News NewsModel, IFormFile file)
        {
            var isCreated = NewsRepo.Update(NewsModel, file);
            if (isCreated is false)
            {
                return View(NewsModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteNews(int id)
        {
            NewsRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
