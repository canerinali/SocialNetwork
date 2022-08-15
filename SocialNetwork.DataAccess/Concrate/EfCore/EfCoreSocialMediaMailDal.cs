using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreSocialMediaMailDal : EfCoreGenericDal<SocialMediaMail, AppDbContext>, ISocialMediaMailDal
    {
    }
}
