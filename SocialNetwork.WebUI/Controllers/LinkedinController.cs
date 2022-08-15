using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Entities;
using SocialNetwork.WebUI.ModelSevrice;
using SocialNetwork.WebUI.ViewModel;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Controllers
{
    public class LinkedinController : Controller
    {
        public IConfiguration configuration;
        ISocialMediaAccountService _socialMediaAccountService;

        public LinkedinController(IConfiguration _configuration, ISocialMediaAccountService socialMediaAccount)
        {
            configuration = _configuration;
            _socialMediaAccountService = socialMediaAccount;
        }

        [HttpGet]
        public async Task<IActionResult> LinkedinToken(string code)
        {
            using (var _modelService = new LinkedinModelService(configuration))
            {
                var token = await _modelService.GetLinkedinToken(code);
                var value = token["access_token"].ToString();

                var linkedinProjection = await _modelService.GetLinkedinProjection(value);
                var firstName = linkedinProjection["firstName"]["localized"]["tr_TR"].ToString();
                var lastName = linkedinProjection["lastName"]["localized"]["tr_TR"].ToString();
                var claimuser = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
                var linkedinAccount = await _modelService.GetLinkedinAccount(value);
                var userId = linkedinAccount["id"].ToString();
                SocialMediaAccount socialMediaAccount = new SocialMediaAccount()
                {
                    CreateDate = DateTime.Now,
                    Enabled = true,
                    UserId = Guid.Parse(claimuser),
                    Username = linkedinAccount["firstName"]["localized"]["tr_TR"].ToString() + " " + linkedinAccount["lastName"]["localized"]["tr_TR"].ToString(),
                    UpdateDate = DateTime.Now,
                    SocialMediaName = "Linkedin",
                    Token = value,
                    SocialId = userId
                };
                _socialMediaAccountService.Create(socialMediaAccount);

                //var LinkedinPostAdd = await _modelService.LinkedinPostAdd(value,userId);

                return RedirectToAction("Index", "SocialMediaAccount");
            }
        }

        [HttpGet]
        public async Task<IActionResult> LinkedinProjection(string token)
        {
            using (var _modelService = new LinkedinModelService(configuration))
            {
                var linkedinProjection = await _modelService.GetLinkedinProjection(token);
                var firstName = linkedinProjection["firstName"]["localized"]["tr_TR"].ToString();
                var lastName = linkedinProjection["lastName"]["localized"]["tr_TR"].ToString();

                return Ok(linkedinProjection);
            }
        }

        [HttpGet]
        public async Task<IActionResult> LinkedinAccount(string token)
        {
            using (var _modelService = new LinkedinModelService(configuration))
            {
                var linkedinAccount = await _modelService.GetLinkedinAccount(token);
                var userId = linkedinAccount["id"].ToString();

                return Ok(linkedinAccount);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LinkedinPost(PostInfo postInfo)
        {
            using (var _modelService = new LinkedinModelService(configuration))
            {
                var claimuser = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
                var socialMediaAccounts = _socialMediaAccountService.GetById((Guid)postInfo.Posts.SocialMediaAccount.Id);
                var token = socialMediaAccounts.Token.ToString();
                var socialid = socialMediaAccounts.SocialId;
                var post = new PostInfo
                {
                    Posts = postInfo.Posts,
                    SocailId = socialid,
                    token = token
                };
                var LinkedinPostAdd = await _modelService.LinkedinPostAdd(post);

                return Ok(LinkedinPostAdd);
            }
        }

    }
}