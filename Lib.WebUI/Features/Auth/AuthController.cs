using Lib.WebUI.Controllers;
using Lib.WebUI.Features.Auth.Models;
using Microsoft.AspNetCore.Http;
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiIxIiwiUm9sZUlkIjoiMSIsIm5iZiI6MTY0MDk2Mjc3NywiZXhwIjoxNjQxMDQ5MTc3LCJpYXQiOjE2NDA5NjI3Nzd9.HQmUbwhszRqls3BDe7UrsmGl2kc_ToSLJQvHHhGFd-0");
                var content = new {
                    Email = model.Email,
                    Password = model.Password
                };
                StringContent t = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("Auth/login", t);

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    AccessToken token = JsonConvert.DeserializeObject<AccessToken>(EmpResponse);
                    var key = "Bearer";
                    CookieOptions options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddMinutes(10)
                    };
                    Response.Cookies.Append(key, token.Token, options);
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

    }

    public class AccessToken
    {
        public string Token { get; set; }
        public string UserID { get; set; }
        public string RoleID { get; set; }
    }
}
