using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Helper
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this JToken token)
        {
            return (token == null) ||
            (token.Type == JTokenType.Array && !token.HasValues) ||
            (token.Type == JTokenType.Object && !token.HasValues) ||
            (token.Type == JTokenType.String && token.ToString() == string.Empty) ||
            (token.Type == JTokenType.Null);
        }
    }
}
