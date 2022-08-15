using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreCommentDal : EfCoreGenericDal<Comment, AppDbContext>, ICommentDal
    {
    }
}
