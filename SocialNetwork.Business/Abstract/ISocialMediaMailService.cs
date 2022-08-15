using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface ISocialMediaMailService
    {
        SocialMediaMail GetById(Guid id);
        List<SocialMediaMail> GetAll();
        void Create(SocialMediaMail entity);
        void Update(SocialMediaMail entity);
        void Delete(SocialMediaMail entity);
    }
}
