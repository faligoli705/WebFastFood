using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebFastFood.Models;

namespace WebFastFood.Controllers
{
    public class AuthenController : Controller
    {
        private readonly ILogger<AuthenController> _logger;
        IHttpClientFactory _httpClientFactory;
        public AuthenController(IHttpClientFactory httpClientFactory, ILogger<AuthenController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(CustomersDto login)
        {
            try
            {
                _logger.LogError("متد Login فراخوانی شد");
                if (!ModelState.IsValid)
                {
                    _logger.LogError("The Model is not valid");
                    return View(login);
                }
                var _client = _httpClientFactory.CreateClient("FastFoodClient");
                var jsonBody = JsonConvert.SerializeObject(login);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var response = _client.PostAsync("/Api/Authen", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var token = response.Content.ReadAsAsync<TokenModel>().Result;
                    var claims = new List<Claim>()
                    {
                         new Claim(ClaimTypes.NameIdentifier,login.Mobile),
                         new Claim(ClaimTypes.Name,login.Mobile),
                         new Claim("AccessToken",token.Token)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var prinsipal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true
                    };
                    HttpContext.SignInAsync(prinsipal, properties);
                    _logger.LogError("کاربر توکن را دریافت و وارد شد");

                    return Redirect("/Customer/Index");

                }
                else
                {
                    ModelState.AddModelError("Mobile", "User not valid or Wrong password");
                    return View(login);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
