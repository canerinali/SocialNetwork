using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business
{
    public partial class Constants
    {
        public class ApiUri
        {
            public const string GetLinkedinToken = "oauth/v2/accessToken?grant_type=authorization_code&code={0}&client_id=78iyhahi3hob5p&client_secret=6sVV02iNIeNSUlnd&redirect_uri=https%3A%2F%2Flocalhost%3A44316%2FLinkedin%2FLinkedinToken";
            public const string GetLinkedinProjection = "me?projection=(id,firstName,lastName,profilePicture(displayImage~:playableStreams))";
            public const string GetLinkedinAccount = "me";
            public const string PostLinkedin = "ugcPosts";



            public const string GetFacebookToken = "v6.0/oauth/access_token?redirect_uri=https%3A%2F%2Flocalhost%3A44316%2FFacebook%2FFacebookToken&client_id=698031151184178&client_secret=c263476ac597bb0e0d6e34b941925d44&code={0}";
            public const string GetFacebookAccount = "me";
        }
    }
}
