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
    public class FacebookController : Controller
    {
        public IConfiguration configuration;
        ISocialMediaAccountService _socialMediaAccountService;

        public FacebookController(IConfiguration _configuration, ISocialMediaAccountService socialMediaAccount)
        {
            configuration = _configuration;
            _socialMediaAccountService = socialMediaAccount;
        }

        [HttpGet]
        public async Task<IActionResult> FacebookToken(string code)
        {
            using (var _modelService = new FacebookModelService(configuration))
            {
                var token = await _modelService.GetFacebookToken(code);
                if (token != null)
                {
                    var value = token["access_token"].ToString();

                    var claimuser = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
                    var linkedinAccount = await _modelService.GetFacebookAccount(value);
                    var userId = linkedinAccount["id"].ToString();
                    SocialMediaAccount socialMediaAccount = new SocialMediaAccount()
                    {
                        CreateDate = DateTime.Now,
                        Enabled = true,
                        UserId = Guid.Parse(claimuser),
                        Username = linkedinAccount["name"].ToString(),
                        UpdateDate = DateTime.Now,
                        SocialMediaName = "Facebook",
                        Token = value,
                        SocialId = userId
                    };
                    _socialMediaAccountService.Create(socialMediaAccount);
                }

                return RedirectToAction("Index", "SocialMediaAccount");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FacebookProjection(string token)
        {
            using (var _modelService = new FacebookModelService(configuration))
            {
                var linkedinProjection = await _modelService.GetFacebookProjection(token);
                var nameSurname = linkedinProjection["name"].ToString().Split(' ')[0];
                var firstName = nameSurname[0].ToString();
                var surName = nameSurname.Last().ToString();

                return Ok(linkedinProjection);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FacebookAccount()
        {
            using (var _modelService = new FacebookModelService(configuration))
            {
                var claimuser = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
                var data = _socialMediaAccountService.GetById(claimuser);
                var token = data.Token.ToString();

                var linkedinAccount = await _modelService.GetFacebookAccount(token);
                var userId = linkedinAccount["id"].ToString();

                return Ok(linkedinAccount);
            }
        }

        [HttpPost]
        public async Task<IActionResult> FacebookPost(PostInfo postInfo)
        {
            using (var _modelService = new FacebookModelService(configuration))
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
                var LinkedinPostAdd = await _modelService.FacebookPostAdd(post);

                return Ok(LinkedinPostAdd);
            }
        }

    }
}