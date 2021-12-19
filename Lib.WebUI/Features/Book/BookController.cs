using Lib.WebUI.Features.Book.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            return View("Cards/_AddAuthor", new AddAuthorViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorViewModel model)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var content = new
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Book/AddAuthor", t);

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

        public IActionResult GenerateCode()
        {
            return View("Cards/_CodeGenerate");
        }

        public IActionResult AddBook()
        {
            return View("Cards/_AddBook", new AddBookViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookViewModel model)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var content = new
                {
                    Title = model.Title,
                    Description = model.Description,
                    AuthorId = model.AuthorId,
                    Cover = model.Cover,
                    BarCode = model.BarCode,
                    IsAvailable = model.IsAvailable
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Book/AddBook", t);

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }


        public IActionResult BookDetails()
        {
            return View("BookDetail");
        }
    }
}
