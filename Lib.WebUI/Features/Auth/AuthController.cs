using Lib.WebUI.Controllers;
using Lib.WebUI.Features.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lib.WebUI.Features.Auth
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            return View("Login/Login", new LoginFormViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginFormViewModel model)
        {
            /*return RedirectToAction(nameof(HomeController.Index), "Home");*/
            return RedirectToAction(nameof(BookController.Index), "Book");
        }
    }
}
