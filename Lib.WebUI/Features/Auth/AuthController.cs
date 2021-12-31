using Lib.WebUI.Controllers;
using Lib.WebUI.Features.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
        public async Task<IActionResult> LoginAsync(LoginFormViewModel model)
        {
            string baseUrl = "https://localhost:44380/";
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var content = new {
                    Email = model.Email,
                    Password = model.Password
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Auth/login", t);

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

    }
}
