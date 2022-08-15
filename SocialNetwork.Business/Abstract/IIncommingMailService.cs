using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface IIncommingMailService
    {
        IncommingMail GetById(Guid id);
        List<IncommingMail> GetAll();
        void Create(IncommingMail entity);
        void Update(IncommingMail entity);
        void Delete(IncommingMail entity);
    }
}
