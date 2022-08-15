using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface ITicketService
    {
        Ticket GetById(Guid id);
        List<Ticket> GetAll();
        void Create(Ticket entity);
        void Update(Ticket entity);
        void Delete(Ticket entity);
    }
}
