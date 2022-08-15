using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreSendMailDal : EfCoreGenericDal<SendMail, AppDbContext>, ISendMailDal
    {
    }
}
