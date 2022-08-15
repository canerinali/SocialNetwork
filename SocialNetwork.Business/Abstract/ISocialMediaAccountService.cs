using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface ISocialMediaAccountService
    {
        SocialMediaAccount GetById(Guid id);
        List<SocialMediaAccount> GetAll();
        void Create(SocialMediaAccount entity);
        void Update(SocialMediaAccount entity);
        void Delete(SocialMediaAccount entity);
    }
}
