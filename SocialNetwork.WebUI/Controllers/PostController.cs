using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Entities;
using SocialNetwork.Entities.Abstract;
using SocialNetwork.WebUI.EntityHelper;
using SocialNetwork.WebUI.Models;
using SocialNetwork.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SocialNetwork.WebUI.Controllers
{
    public class PostController : Controller
    {
        IPostService _postService;
        ISocialMediaAccountService _socialMediaAccountService;
        IBaseHelper _baseHelper;

        public PostController(ISocialMediaAccountService socialMediaAccountService,IPostService postService, IBaseHelper baseHelper)
        {
            _socialMediaAccountService = socialMediaAccountService;
            _postService = postService;
            _baseHelper = baseHelper;
        }

        public IActionResult Index()
        {
            return View(_postService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var linkedinId = _socialMediaAccountService.GetAll();
            //var claimuser = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            //var result = new PostInfo()
            //{
            //    SocialMediaAccount = socialMediaAccounts,
            //    LinkedinuserId = claimuser.ToString(),
            //    UserId = claimuser,
            //};
            List<SocialMediaAccount> socialMediaAccountslist = SocialMediaAccounts();

            ViewData["SocialMediaAccounts"] = socialMediaAccountslist;
            return View();
        }

        public List<SocialMediaAccount> SocialMediaAccounts()
        {
            var claimuser = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            List<SocialMediaAccount> socialMediaAccounts;

            var socialMediaAccountsa = _socialMediaAccountService.GetAll().ToList().Where(x => x.UserId == claimuser).ToList();

            return socialMediaAccountsa;
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View(post);

            post.CalendarJs = JsonConvert.SerializeObject(new CalendarJs()
            {
                backgroundColor = "#0073b7",
                borderColor = "#0073b7",
                title = post.Title,
                url = "/Post/Update/" +post.Id.ToString(),
                Year = post.TaskDate.Year,
                Month = post.TaskDate.Month - 1,
                Day = post.TaskDate.Day,
                Hour = post.TaskDate.Hour,
                Minute = post.TaskDate.Minute
            });

            _baseHelper.CreateDefaultProperty(post);
            _postService.Create(post);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var post = _postService.GetById(id);
            _postService.Delete(post);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            return View(_postService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Post post)
        {
            if (!ModelState.IsValid)
                return View(post);

            _baseHelper.UpdateDefaultProperty(post);
            _postService.Update(post);

            return RedirectToAction("Update");
        }
    }
}
