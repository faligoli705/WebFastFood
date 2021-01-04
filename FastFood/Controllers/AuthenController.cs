using FastFood.DataLayer.DataAccess;
using FastFood.DataLayer.Services;
using FastFood.DataLayer.Services.Contracts;
using FastFood.DataLayer.Services.Repository;
using FastFood.DomainClass.Domain.Dto;
using FastFood.DomainClass.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]

    public class AuthenController : Controller
    {
        private readonly ILogger<AuthenController> _logger;

       private readonly IAuthen _authen;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authen"></param>
        public AuthenController(IAuthen authen, ILogger<AuthenController> logger)
        {
            _authen = authen;
            _logger = logger;
        }
        /// <summary>
        /// لاگین شدن و اعتبار سنجی کاربر
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult PostLogin(CustomersDto login)
        {

            _logger.LogInformation("متد Login فراخوانی شد");

            var mobile = login.Mobile;
            var passwordCustomer = login.PasswordCustomer;
            if (!ModelState.IsValid)
            {
                _logger.LogError("The Model is not valid");
                return BadRequest("The Model is not valid");
            }
            
            var user = _authen.ListcustomersLogin(mobile, passwordCustomer);
            if (user == null)
            {
                _logger.LogError("نام کاربری یا رمز عبور اشتباه است یا کاربر وجود ندارد");
                return BadRequest("Not exist user");
            }
            if (login.Mobile != user.Mobile || login.PasswordCustomer != user.PasswordCustomer)
            {
                _logger.LogError("نام کاربری یا رمز اشتباه است");
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890 OurVerifyDotin"));
            var signinCredintioals = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOption = new JwtSecurityToken(
                issuer: "http://localhost:64467",
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name,login.Mobile),
                    //new Claim(ClaimTypes.Name,login.FName),
                    new Claim(ClaimTypes.Role,"Admin")
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredintioals
                );
            _logger.LogInformation("توکن ایجاد شد");
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
            return Ok(new { token = tokenString });
        }
    }
}
