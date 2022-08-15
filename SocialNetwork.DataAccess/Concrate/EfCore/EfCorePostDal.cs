using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCorePostDal : EfCoreGenericDal<Post, AppDbContext>, IPostDal
    {
    }
}
