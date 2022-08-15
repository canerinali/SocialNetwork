using Microsoft.AspNetCore.Http;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Helpers;

namespace SocialNetwork.WebUI.Models
{
    public class CacheHelper
    {
        private static ISocialMediaAccountService _socialMediaAccountService;
        public static readonly IHttpContextAccessor httpContextAccessor;

        public static List<SocialMediaAccount> GetSocialFromCache()
        {
            var claimuser = httpContextAccessor.HttpContext
                         .User.Claims
                         .FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

            var result = WebCache.Get("social-cache");

            if (result == null)
            {
                var data = _socialMediaAccountService.GetAll().Where(x => x.UserId == Guid.Parse(claimuser));

                WebCache.Set("social-cache", result, 20, true);
            }

            return result;
        }
    }
}