using Lib.WebUI.Features.Book.Models;
using Lib.WebUI.Features.Statistics.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Lib.WebUI.Controllers
{
    public class StatisticsController : Controller
    {
        public async Task<IActionResult> Index()
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

                HttpResponseMessage res = await client.GetAsync("Book/GetStatistics");

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    StatisticsQuantityViewModel model = await res.Content.ReadAsAsync<StatisticsQuantityViewModel>();
                    return View("Statistics", model);
                }
            }
            return View("Statistics");
        }

        public async Task<JsonResult> GetStatistics()
        {
            var isAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            ViewBag.IsAuthenticated = isAuthenticated;

            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                HttpResponseMessage res = await client.GetAsync("Book/GetStatistics");

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    StatisticsQuantityViewModel model = await res.Content.ReadAsAsync<StatisticsQuantityViewModel>();

                    return Json(model);
                }
            }

            return Json(false);
        }

        public async Task<JsonResult> GetUserStatistics()
        {
            var isAuthenticated = Request.Cookies["RoleID"] == "1" ? true : false;
            ViewBag.IsAuthenticated = isAuthenticated;
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                HttpResponseMessage res = await client.GetAsync("Auth/getUsersStatistics");

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    UsersStatistics model = await res.Content.ReadAsAsync<UsersStatistics>();

                    return Json(model);
                }
            }

            return Json(false);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksStatistics(long id)
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

                HttpResponseMessage res = await client.GetAsync(string.Format("Book/GetBooksinformation", id));

                if (res.IsSuccessStatusCode)
                {
                    var bookCollection = await res.Content.ReadAsAsync<BooksStatisticsViewModel>();
                    var model = new BooksStatisticsViewModel()
                    {
                        BorrowBooks = bookCollection.BorrowBooks,
                        AllBooks = bookCollection.AllBooks
                    };
                    return View("AllBookInformation", model);
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

    }
}
