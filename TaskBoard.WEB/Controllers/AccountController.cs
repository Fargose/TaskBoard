using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using TaskBoard.BLL.DTO;
using TaskBoard.BLL.Interfaces;
using TaskBoard.DAL.Entities;
using TaskBoard.WEB.ViewModels;

namespace TaskBoard.WEB.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IStringLocalizer _localizer;
        private readonly IUserService UserService;

        public AccountController(SignInManager<UserAccount> signInManager, IUserService userService, IStringLocalizer strlocalizer)
        {

            _signInManager = signInManager;
            UserService = userService;
            _localizer = strlocalizer;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO
                {
                    Password = model.Password,
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.Name,
                    SurName = model.SurName,
                    Language = "uk-UA"
                };
                var result = await UserService.CreateUser(user);
                if (result.Succedeed)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
              
                    ModelState.AddModelError(string.Empty, _localizer[result.Message]);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    SetLanguage(UserService.GetUser(model.Email).Language, model.Email);
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {

                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", _localizer["BadCredentianal"]);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string email = "", string returnUrl = "")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
              
            );
            if(email.Trim() != "")
            {
                UserService.SetLanguage(email, culture);
            }
          
            if (returnUrl != "")
            {
                return LocalRedirect(returnUrl);
            }
            return new EmptyResult();
        }
    }
}