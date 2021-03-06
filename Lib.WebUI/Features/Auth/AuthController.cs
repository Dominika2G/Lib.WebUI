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
using System.Security.Claims;


//namespace Lib.WebUI.Features.Auth
namespace Lib.WebUI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View("Login/Login", new LoginFormViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login/Login", model);
            }
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
                    AccessToken token = JsonConvert.DeserializeObject<AccessToken>(EmpResponse);
                    if (token.Token == "Brak tokenu")
                    {
                        ViewBag.ErrorAuthorize = "*Podano złe dane logowania lub konto jest nieaktywne. Prosze skontaktować sie z administratorem.";
                        return View("Login/Login", model);
                    }
                    var key = "Bearer";
                    var UserId = "UserID";
                    var RoleId = "RoleID";
                    if(token.RoleID == "1")
                    {
                        ViewBag.IsAuthenticated = true;
                    }else
                    {
                        ViewBag.IsAuthenticated = false;
                    }
                    ViewBag.Role = token.RoleID;
                    CookieOptions options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddMinutes(10)
                    };
                    Response.Cookies.Append(key, token.Token, options);
                    Response.Cookies.Append(UserId, token.UserID, options);
                    Response.Cookies.Append(RoleId, token.RoleID, options);
                }
            }
            return RedirectToAction(nameof(BookController.Index), "Book");
        }

        public IActionResult LogOut()
        {
            Response.Cookies.Delete("Bearer");
            Response.Cookies.Delete("UserID");
            Response.Cookies.Delete("RoleID");

            return RedirectToAction(nameof(AuthController.Index), "Auth");
        }
        [HttpGet]
        public bool IsAuthenticated()
        {
            var cookies = Request.Cookies["RoleId"];
            if(cookies == "1")
            {
                return true;
            }else
            {
                return false;
            }
        }

    }

    public class AccessToken
    {
        public string Token { get; set; }
        public string UserID { get; set; }
        public string RoleID { get; set; }
    }
}
