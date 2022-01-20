using BarcodeLib;
using Lib.WebUI.Features.Auth;
using Lib.WebUI.Features.Book.Models;
using Lib.WebUI.Features.User.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib.WebUI.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                HttpResponseMessage res = await client.GetAsync("Book/AllBooks");

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    BookViewModel books = await res.Content.ReadAsAsync<BookViewModel>();
                    var model = new BookAuthenticationViewModel()
                    {
                        BookDetails = books.BookDetails,
                        IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false
                };

                    return View("Books", model);
                }
            }
            return RedirectToAction(nameof(AuthController.Index), "Auth");
        }

        public IActionResult AddAuthor()
        {
            var isAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            ViewBag.IsAuthenticated = isAuthenticated;
            if (isAuthenticated)
            {
                return View("Cards/_AddAuthor", new AddAuthorViewModel());
            }else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorViewModel model)
        {
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            if (!ModelState.IsValid)
            {
                return View("Cards/_AddAuthor", model);
            }

            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);
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

        public async Task<IActionResult> AddBookAsync()
        {
            var isAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            ViewBag.IsAuthenticated = isAuthenticated;
            if (!isAuthenticated)
            {
                return View("Error");
            }
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

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
            var isAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            ViewBag.IsAuthenticated = isAuthenticated;
            if (!ModelState.IsValid)
            {
                string baseUrl2 = "https://localhost:44380/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl2);
                    client.DefaultRequestHeaders.Clear();
                    var cookies = Request.Cookies["Bearer"];
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                    HttpResponseMessage res = await client.GetAsync("Book/GetAuthors");

                    if (res.IsSuccessStatusCode)
                    {
                        var EmpResponse = res.Content.ReadAsStringAsync().Result;
                        List<Author> x = await res.Content.ReadAsAsync<List<Author>>();
                        model.Authors = x;
                        return View("Cards/_AddBook", model);
                    }
                }
            }

            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);
                var content = new
                {
                    Title = model.Title,
                    Description = model.Description,
                    AuthorId = model.AuthorId,
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
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

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
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);
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
        public async Task<IActionResult> ReturnBook(BookReturnRequest model)
        {
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);
                var content = new
                {
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
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);
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
        public async Task<IActionResult> MakeReservation(long id)
        {
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                HttpResponseMessage res = await client.GetAsync("Auth/getUsers");

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    UserCollectionViewModel x = await res.Content.ReadAsAsync<UserCollectionViewModel>();
                    var model = new MakeReservationViewModel()
                    {
                        UsersCollection = x.UsersCollection,
                        BookId = id
                    };

                    return View("Cards/_borrowBook", model);
                }
            }

            return View("Cards/_borrowBook", new AddBookViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> BorrowBook(Bookstatusrequest model)
        {
            var isAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            ViewBag.IsAuthenticated = isAuthenticated;
            if (!isAuthenticated)
            {
                return View("Error");
            }
            if (!ModelState.IsValid)
            {
                string baseUrl2 = "https://localhost:44380/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl2);
                    client.DefaultRequestHeaders.Clear();
                    var cookies = Request.Cookies["Bearer"];
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                    HttpResponseMessage res = await client.GetAsync("Auth/getUsers");

                    if (res.IsSuccessStatusCode)
                    {
                        var EmpResponse = res.Content.ReadAsStringAsync().Result;
                        UserCollectionViewModel x = await res.Content.ReadAsAsync<UserCollectionViewModel>();
                        var model2 = new MakeReservationViewModel()
                        {
                            UsersCollection = x.UsersCollection,
                            BookId = model.BookId
                        };


                        return View("Cards/_borrowBook", model2);
                    }
                }
            }
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);
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

        public string Search(string data)
        {
            return data;
        }

        [HttpGet]
        public async Task<IActionResult> SearchBook(string data)
        {
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                HttpResponseMessage res = await client.GetAsync(string.Format("Book/GetSelectedBook?TitleOrBarCode={0}", data));

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    BookViewModel books = await res.Content.ReadAsAsync<BookViewModel>();
                    var model = new BookAuthenticationViewModel()
                    {
                        BookDetails = books.BookDetails,
                        IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false
                };
                    return View("Books", model);
                }
            }
            return View("Books");
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentRequest model)
        {
            ViewBag.IsAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);
                var content = new
                {
                    Description = model.Description,
                    Rating = model.Rating,
                    BookId = model.BookId
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Book/AddComment", t);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(BookController.Index), "Book");
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }
    }
}
