using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SocialNetwork.Business;
using SocialNetwork.WebUI.Business;
using SocialNetwork.WebUI.Helper;
using SocialNetwork.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace SocialNetwork.WebUI.ModelSevrice
{
    public class FacebookModelService : BLBase
    {
        public FacebookModelService(IConfiguration _configuration) : base(_configuration)
        {
        }
        public async Task<JObject> GetFacebookToken(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                using (var client = HttpClient(Enums.ContentType.JSON, Enums.SocailName.Facebook))
                {
                    var url = string.Format(Constants.ApiUri.GetFacebookToken, code);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        return JObject.Parse(result);
                    }
                }
            }

            return null;
        }
        public async Task<JObject> GetFacebookProjection(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                using (var client = HttpClient(Enums.ContentType.JSON, Enums.SocailName.Facebook))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var url = string.Format(Constants.ApiUri.GetFacebookAccount);

                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        return JObject.Parse(result);
                    }
                }
            }

            return null;
        }
        public async Task<JObject> GetFacebookAccount(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                using (var client = HttpClient(Enums.ContentType.JSON, Enums.SocailName.Facebook))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var url = string.Format(Constants.ApiUri.GetFacebookAccount);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        return JObject.Parse(result);
                    }
                }
            }

            return null;
        }
        public async Task<JObject> FacebookPostAdd(PostInfo postInfo)
        {
            if (postInfo != null)
            {
                using (var client = HttpClient(Enums.ContentType.JSON, Enums.SocailName.Facebook))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", postInfo.token);
                    client.DefaultRequestHeaders.Add("x-restli-protocol-version", "2.0.0");

                    var url = string.Format(Constants.ApiUri.PostLinkedin);

                    string json = $@"{{
                        ""author"": ""urn:li:person:{postInfo.SocailId}"",
                        ""lifecycleState"": ""PUBLISHED"",
                        ""specificContent"": {{
                            ""com.linkedin.ugc.ShareContent"": {{
                                ""shareCommentary"": {{
                                    ""text"": ""{postInfo.Posts.Text}""
                                }},
                                ""shareMediaCategory"": ""NONE""
                            }}
                        }},
                        ""visibility"": {{
                            ""com.linkedin.ugc.MemberNetworkVisibility"": ""PUBLIC""
                        }}
                    }}";

                    JObject o = JObject.Parse(json);

                    var response = await client.PostAsJsonAsync(url, o);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JObject.Parse(result);
                    }
                }
            }

            return null;
        }
    }
}