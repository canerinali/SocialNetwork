using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface ISendMailService
    {
        SendMail GetById(Guid id);
        List<SendMail> GetAll();
        void Create(SendMail entity);
        void Update(SendMail entity);
        void Delete(SendMail entity);
    }
}
