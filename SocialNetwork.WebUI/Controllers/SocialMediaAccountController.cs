using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Entities;
using SocialNetwork.WebUI.EntityHelper;
using SocialNetwork.WebUI.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace SocialNetwork.WebUI.Controllers
{
    public class SocialMediaAccountController : Controller
    {

        ISocialMediaAccountService _socialMediaAccountService;
        IUserService _userService;
        IBaseHelper _baseHelper;

        public SocialMediaAccountController(ISocialMediaAccountService socialMediaAccountService, IUserService userService, IBaseHelper baseHelper)
        {
            _socialMediaAccountService = socialMediaAccountService;
            _userService = userService;
            _baseHelper = baseHelper;
        }

        public IActionResult Index()
        {
            var claimuser = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            var socialMediaAccounts = _socialMediaAccountService.GetAll().ToList().Where(x => x.UserId == claimuser).ToList();
            return View(socialMediaAccounts);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View(_socialMediaAccountService.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(SocialMediaAccount socialMediaAccount)
        {
            _socialMediaAccountService.Delete(socialMediaAccount);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            return View(_socialMediaAccountService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(SocialMediaAccount socialMediaAccount)
        {
            if (!ModelState.IsValid)
                return View(socialMediaAccount);

            _baseHelper.UpdateDefaultProperty(socialMediaAccount);
            _socialMediaAccountService.Update(socialMediaAccount);

            return RedirectToAction("Update");
        }
    }
}
