using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View("Books");
        }

        public IActionResult AddAuthor()
        {
            return View("Cards/_AddAuthor");
        }

        public IActionResult GenerateCode()
        {
            return View("Cards/_CodeGenerate");
        }

        public IActionResult AddBook()
        {
            return View("Cards/_AddBook");
        }

        public IActionResult BookDetails()
        {
            return View("BookDetail");
        }
    }
}
