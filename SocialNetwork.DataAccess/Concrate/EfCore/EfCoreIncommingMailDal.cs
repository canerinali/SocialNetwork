using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreIncommingMailDal : EfCoreGenericDal<IncommingMail, AppDbContext>, IIncommingMailDal
    {
    }
}
