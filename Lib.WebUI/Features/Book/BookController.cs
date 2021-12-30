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
        public async Task<IActionResult> Index()
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                
                HttpResponseMessage res = await client.GetAsync("Book/AllBooks");

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    BookViewModel books = await res.Content.ReadAsAsync<BookViewModel>();
                    var model = new BookViewModel()
                    {
                        BookDetails = books.BookDetails
                    };
                    return View("Books", model);
                }
            }
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

        public async Task<IActionResult> AddBookAsync()
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage res = await client.GetAsync("Book/GetAuthors");

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    List<Author> x = await res.Content.ReadAsAsync<List<Author>>();
                    var model = new AddBookViewModel()
                    {
                        Authors = x
                    };

                    return View("Cards/_AddBook", model);
                }
            }
            
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
                    //AuthorId = 1,
                    Cover = "",
                    BarCode = model.BarCode,
                    IsAvailable = true,
                    IsReserved = false
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

        [HttpGet]
        public async Task<IActionResult> BookDetails(long id)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage res = await client.GetAsync(string.Format("Book/BookDetail?Id={0}", id));

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    var model = await res.Content.ReadAsAsync<BookDetailViewModel>();

                    return View("BookDetail", model);
                }
            }
            return View("BookDetail");
        }

        [HttpPost]
        public async Task<IActionResult> BookReserved(Bookstatusrequest model)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var content = new
                {
                    UserId = model.UserId,
                    BookId = model.BookId
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Book/BookReservation", t);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(BookController.Index), "Book");
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(Bookstatusrequest model)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var content = new
                {
                    UserId = model.UserId,
                    BookId = model.BookId
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Book/ReturnBook", t);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(BookController.Index), "Book");
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStateReservation(Bookstatusrequest model)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var content = new
                {
                    UserId = model.UserId,
                    BookId = model.BookId
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Book/ChangeBookReservation", t);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(BookController.Index), "Book");
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

        [HttpPost]
        public async Task<IActionResult> BorrowBook(Bookstatusrequest model)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var content = new
                {
                    UserId = model.UserId,
                    BookId = model.BookId
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Book/BorrowBook", t);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(BookController.Index), "Book");
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

        /*[HttpGet]
        public async Task<IActionResult> GetUserBooks()
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage res = await client.GetAsync("Book/GetUserBooks");

                if (res.IsSuccessStatusCode)
                {
                    var bookCollection = await res.Content.ReadAsAsync<List<UserBooks>>();
                    var model = new UserBooksViewModel()
                    {
                        Books = bookCollection
                    };
                    return View("Cards/_UserModal", model);
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }*/
    }
}
