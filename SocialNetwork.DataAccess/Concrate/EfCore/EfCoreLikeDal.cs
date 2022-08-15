using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreLikeDal : EfCoreGenericDal<Like, AppDbContext>, ILikeDal
    {
    }
}
