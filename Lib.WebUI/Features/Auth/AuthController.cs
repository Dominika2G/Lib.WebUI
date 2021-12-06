using Lib.WebUI.Controllers;
using Lib.WebUI.Features.Auth.Models;
using Lib.WebUI.Features.Book;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
