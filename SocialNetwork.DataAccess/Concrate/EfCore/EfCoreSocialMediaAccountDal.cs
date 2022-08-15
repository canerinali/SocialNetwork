using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreSocialMediaAccountDal : EfCoreGenericDal<SocialMediaAccount, AppDbContext>, ISocialMediaAccountDal
    {
    }
}
