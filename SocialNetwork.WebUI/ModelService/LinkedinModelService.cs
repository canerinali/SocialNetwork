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
    public class LinkedinModelService : BLBase
    {
        public LinkedinModelService(IConfiguration _configuration) : base(_configuration)
        {
        }
        public async Task<JObject> GetLinkedinToken(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                using (var client = HttpClient(Enums.ContentType.JSON, Enums.SocailName.Linkedin))
                {
                    //var url = "http://myserver/method";
                    //var parameters = new Dictionary<string, string> { { "param1", "1" }, { "param2", "2" } };
                    //var encodedContent = new FormUrlEncodedContent(parameters);

                    //var response = await httpclient.PostAsync(url, encodedContent).ConfigureAwait(false);

                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "authorization_code"),
                        new KeyValuePair<string, string>("code", code ),
                        new KeyValuePair<string, string>( "client_id", _configuration["LinkedinAuth:ClientID"] ),
                        new KeyValuePair<string, string>("client_secret", _configuration["LinkedinAuth:ClientSecret"] ),
                        new KeyValuePair<string, string>("redirect_uri", "https%3A%2F%2Flocalhost%3A44316%2FSocialMediaAccount%2FConnectSocial"),
                    });

                    var obj = new JObject();
                    obj["grant_type"] = "authorization_code";
                    obj["code"] = code;
                    obj["client_id"] = _configuration["LinkedinAuth:ClientID"];
                    obj["client_secret"] = _configuration["LinkedinAuth:ClientSecret"];
                    obj["redirect_uri"] = "https%3A%2F%2Flocalhost%3A44316%2FSocialMediaAccount%2FConnectSocial";
                    var parameters = new Dictionary<string, string> { { "grant_type", "authorization_code" }, { "code", code }, { "client_id", _configuration["LinkedinAuth:ClientID"] }, { "client_secret", _configuration["LinkedinAuth:ClientSecret"] }, { "redirect_uri", "https%3A%2F%2Flocalhost%3A44316%2FSocialMediaAccount%2FConnectSocial" } };

                    //var clientId = _configuration["LinkedinAuth:ClientID"];
                    //var clientSecret = _configuration["LinkedinAuth:ClientSecret"];
                    //var redirect_uri = _configuration["LinkedinAuth:redirect_uri"];
                    client.BaseAddress = client.BaseAddress = new Uri("https://www.linkedin.com/");

                    var url = string.Format(Constants.ApiUri.GetLinkedinToken, code);
                    var encodedContent = new FormUrlEncodedContent(parameters);

                    var response = await client.PostAsJsonAsync(url, obj);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        return JObject.Parse(result);
                    }
                }
            }

            return null;
        }
        public async Task<JObject> GetLinkedinProjection(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                using (var client = HttpClient(Enums.ContentType.JSON, Enums.SocailName.Linkedin))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var url = string.Format(Constants.ApiUri.GetLinkedinProjection);

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
        public async Task<JObject> GetLinkedinAccount(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                using (var client = HttpClient(Enums.ContentType.JSON, Enums.SocailName.Linkedin))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var url = string.Format(Constants.ApiUri.GetLinkedinAccount);

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
        public async Task<JObject> LinkedinPostAdd(PostInfo postInfo)
        {
            if (postInfo != null)
            {
                using (var client = HttpClient(Enums.ContentType.JSON, Enums.SocailName.Linkedin))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", postInfo.token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Add("X-Restli-Protocol-Version", "2.0.0");
                    //client.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");

                    var url = string.Format(Constants.ApiUri.PostLinkedin);

                    string json = $@"{{
                        ""author"": ""urn:li:person:{postInfo.SocailId}"",
                        ""lifecycleState"": ""PUBLISHED"",
                        ""specificContent"": {{
                            ""com.linkedin.ugc.ShareContent"": {{
                                ""shareCommentary"": {{
                                    ""text"": ""{postInfo.Posts.Text}""
                                }},
                                ""shareMediaCategory"": ""ARTICLE"",
                                ""media"": [
                                     {{
                                         ""status"": ""READY"",
                                         ""description"": {{
                                             ""text"": ""asdfasdfsadfasdf.""
                                         }},
                                         ""originalUrl"": ""https://blog.linkedin.com/"",
                                         ""title"": {{
                                             ""text"": ""Official LinkedIn Blog""
                                         }}
                                     }}
                                 ] 
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
                    else
                    {
                        var resfdsdf = response.Content.ReadAsStringAsync();
                        var aksdfjasd = resfdsdf.Result.ToString();
                    }
                }
            }

            return null;
        }
    }
}