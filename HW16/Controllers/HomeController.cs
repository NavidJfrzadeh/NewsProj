using HW16.Models;
using Infrastructure.EF.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW16.Controllers
{
    public class HomeController : Controller
    {
        NewsRepository NewsRepo = new NewsRepository();
        public IActionResult Index()
        {
            var AllNews = NewsRepo.GetActiveNews();
            return View(AllNews);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
