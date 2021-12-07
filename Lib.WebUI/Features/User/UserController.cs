using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.User
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("Users");
        }

        public IActionResult AddUser()
        {
            return View("Cards/_AddUser");
        }

        public IActionResult EditUser()
        {
            return View("Cards/_EditUser");
        }
    }
}
