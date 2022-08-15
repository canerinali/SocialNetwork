using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.ViewModel
{
    public class PostInfo
    {
        public string SocailId { get; set; }
        public string token { get; set; }
        public Post Posts { get; set; }
    }
}
