using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Concrate
{
    public class TicketManager : ITicketService
    {
        private ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public void Create(Ticket entity)
        {
            _ticketDal.Create(entity);
        }

        public void Delete(Ticket entity)
        {
            _ticketDal.Delete(entity);
        }

        public List<Ticket> GetAll()
        {
            return _ticketDal.GetAll();
        }

        public Ticket GetById(Guid id)
        {
            return _ticketDal.GetById(id);
        }

        public void Update(Ticket entity)
        {
            _ticketDal.Update(entity);
        }
    }
}
