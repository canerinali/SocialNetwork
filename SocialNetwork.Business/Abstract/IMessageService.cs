using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
namespace SocialNetwork.Business.Abstract
{
    public interface IMessageService
    {
        Message GetById(Guid id);
        List<Message> GetAll();
        void Create(Message entity);
        void Update(Message entity);
        void Delete(Message entity);
    }
}
