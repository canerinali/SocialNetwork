using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Entities;
using SocialNetwork.WebUI.EntityHelper;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        IUserService _userService;
        IBaseHelper _baseHelper;

        public AuthorizationController(IUserService userService, IBaseHelper baseHelper)
        {
            _userService = userService;
            _baseHelper = baseHelper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetGuidByMailPass(loginVM.Mail, loginVM.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        new Claim(ClaimTypes.Surname, user.Surname),
                        new Claim(ClaimTypes.Email, user.Mail)
                    };

                    var userIdentity = new ClaimsIdentity(claims, "Login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(loginVM);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _baseHelper.CreateDefaultProperty(user);
            _userService.Create(user);

            return RedirectToAction("Authorization", "Register");
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
