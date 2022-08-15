using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SocialNetwork.WebUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Business
{
    public class BLBase : IDisposable
    {
        public IConfiguration _configuration;
        private static string Token;
        private static DateTime? TokenExpireDate;


        public BLBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HttpClient HttpClient(string contentType, string socialName)
        {
            var client = new HttpClient();
            switch (socialName)
            {
                default:
                case "Linkedin":
                    client = new HttpClient
                    {
                        BaseAddress = new Uri("https://api.linkedin.com/v2/")
                    };
                    break;
                case "Instagram":
                case "Facebook":
                    client = new HttpClient
                    {
                        BaseAddress = new Uri("https://graph.facebook.com/")
                    };
                    break;
            }

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(contentType));
            if (string.IsNullOrEmpty(Token))
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            else
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetLinkedinToken());

            return client;
        }

        private string GetLinkedinToken()
        {
            if (!string.IsNullOrEmpty(Token) && TokenExpireDate.HasValue && TokenExpireDate > DateTime.Now.ToUniversalTime())
                return Token;

            using (var client = new HttpClient())
            {
                var clientId = _configuration["LinkedinAuth:ClientID"];
                var clientSecret = _configuration["LinkedinAuth:ClientSecret"];
                var redirect_uri = _configuration["LinkedinAuth:redirect_uri"];

                //var data = new
                //{
                //    response_type = "code",
                //    clientId = clientId,
                //    clientSecret = clientSecret,
                //    redirect_uri = redirect_uri
                //};
                var response = client.GetAsync("oauth/v2/authorization?response_type=code&client_id=78iyhahi3hob5p&redirect_uri=https%3A%2F%2Fmcoracarrental.com&state=foobar&scope=r_liteprofile%20r_emailaddress%20w_member_social").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    TokenExpireDate = DateTime.Now.AddDays(30);
                    Token = result["access_token"].ToString();
                    return Token;
                }
                else
                    return string.Empty;


            }

        }
        public void Dispose()
        {
        }
    }
}
