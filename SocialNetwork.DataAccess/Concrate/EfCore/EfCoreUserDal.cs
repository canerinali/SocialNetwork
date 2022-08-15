using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreUserDal : EfCoreGenericDal<User, AppDbContext>, IUserDal
    {
    }
}
