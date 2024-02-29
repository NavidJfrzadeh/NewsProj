using Entities;
using HW16.Models;
using Infrastructure.EF.DataBases;
using Infrastructure.EF.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW16.Controllers
{
    public class AutenticationController : Controller
    {
        ReporterService reporterService = new ReporterService();
        AdminService adminService = new AdminService();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsAdmin)
                {
                    var admin = adminService.CheckLogin(model.Emai, model.Password);
                    if (admin != null)
                    {
                        InMemoryDataBase.OnlineAdmin = admin;
                        TempData["success"] = "ورود با دسترسی ادمین";
                        return RedirectToAction("Index", "Admin");
                    }
                    TempData["notFound"] = "حساب شما پیدا نشد! ثبت نام کنید";
                    return RedirectToAction("Register");
                }

                var Reporter = reporterService.CheckLogin(model.Emai, model.Password);
                if (Reporter != null)
                {
                    InMemoryDataBase.OnlineReporter = Reporter;
                    TempData["success"] = "ورود با موفقیت انجام شد";
                    return RedirectToAction("Index", "Reporter");
                }
                TempData["notFound"] = "حساب شما پیدا نشد! ثبت نام کنید";
                return RedirectToAction("Register");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Reporter newReporter)
        {
            if (ModelState.IsValid)
            {
                var isRegisterd = reporterService.AddReporter(newReporter);
                if (isRegisterd)
                    return RedirectToAction("Login");
            }
            return View(newReporter);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
