using EShopper.Business.Services;
using EShopper.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using EShopper.Common.Statics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System;

namespace EShopper.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var result = _userService.GetUserByNameAndPassword(userLoginDto.Username, userLoginDto.Password);
            if (result != null)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim("Username",result.Username),
                    new Claim(MyClaimTypes.FullName,string.Format("{0} {1}",result.FirstName,result.LastName)),
                    new Claim("EmailAddress",result.EmailAddress),
                    new Claim("Id",result.Id.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateDto userCreateDto)
        {
            var result = _userService.CreateUser(userCreateDto);
            TempData["Message"] = result;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult SetLangauge(string culture)
        {
            Response.Cookies.Append(
                 CookieRequestCultureProvider.DefaultCookieName,
                 CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                 new CookieOptions
                 {
                     Expires = DateTimeOffset.UtcNow.AddYears(1),
                     IsEssential = true,
                     Path = "/",
                     HttpOnly = false,
                 }
            );

            return Json("Başarılı");
        }
    }
}