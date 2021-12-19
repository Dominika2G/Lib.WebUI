using Lib.WebUI.Features.User.Models;
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
    public class UserController : Controller
    {
        public IActionResult Index()
        {
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
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage Res = await client.GetAsync("WeatherForecast");
                var content = new
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    RoleId = model.RoleId,
                    PasswordHash = model.Password,
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

        public IActionResult EditUser()
        {
            return View("Cards/_EditUser");
        }
    }
}
