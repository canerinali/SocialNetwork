using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreMessageDal : EfCoreGenericDal<Message, AppDbContext>, IMessageDal
    {
    }
}
