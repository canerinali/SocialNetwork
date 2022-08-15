using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface ILikeService
    {
        Like GetById(Guid id);
        List<Like> GetAll();
        void Create(Like entity);
        void Update(Like entity);
        void Delete(Like entity);
    }
}
