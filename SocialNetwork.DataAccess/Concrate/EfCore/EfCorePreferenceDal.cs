using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCorePreferenceDal : EfCoreGenericDal<Preference, AppDbContext>, IPreferenceDal
    {
    }
}
