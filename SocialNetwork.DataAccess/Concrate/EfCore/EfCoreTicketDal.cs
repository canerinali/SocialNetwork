using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;

namespace SocialNetwork.DataAccess.Concrate.EfCore
{
    public class EfCoreTicketDal : EfCoreGenericDal<Ticket, AppDbContext>, ITicketDal
    {
    }
}
