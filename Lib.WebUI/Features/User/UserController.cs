using Lib.WebUI.Features.Book.Models;
using Lib.WebUI.Features.User.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib.WebUI.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                HttpResponseMessage res = await client.GetAsync("Auth/GetUsers");

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    var books = await res.Content.ReadAsAsync<UserCollectionViewModel>();
                    var model = new UserCollectionViewModel()
                    {
                        UsersCollection = books.UsersCollection
                    };
                    return View("Users", model);
                }
            }
            return View("Users");
        }

        public IActionResult AddUser()
        {
            return View("Cards/_AddUser", new CreateUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserViewModel model)
        {
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
                    LastName = model.LastName,
                    Email = model.Email,
                    RoleId = model.RoleId,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    Class = model.Class
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Auth/register", t);

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                }

            }

                return RedirectToAction(nameof(BookController.Index), "Book");
        }

        public IActionResult EditUser(long id)
        {
            var model = new EditUserViewModel()
            {
                UserId = id
            };
            return View("Cards/_EditUser", model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
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
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    IsActive = model.IsActive
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Auth/EditUser", t);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(UserController.Index), "User");
                }
            }

            return RedirectToAction(nameof(UserController.Index), "User");
        }
        [HttpGet]
        public IActionResult ShowStatistics()
        {
            return PartialView("Cards/_UserModal");
        }


        [HttpGet]
        public async Task<IActionResult> GetUserBooks(long id)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);

                HttpResponseMessage res = await client.GetAsync(string.Format("Book/GetUserBooks?Id={0}", id));

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
        }

        public IActionResult ChangePassword()
        {
            return View("Cards/_ChangePassword", new ChangePasswordRequest());
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest model)
        {
            string baseUrl = "https://localhost:44380/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var cookies = Request.Cookies["Bearer"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookies);
                var content = new
                {
                    OldPassword = model.Password,
                    NewPassword = model.ConfirmPassword
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Auth/changePassword", t);

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                }

            }

            return RedirectToAction(nameof(BookController.Index), "Book");
        }
    }
}
