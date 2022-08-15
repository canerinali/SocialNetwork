using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface ICommentService
    {
        Comment GetById(Guid id);
        List<Comment> GetAll();
        void Create(Comment entity);
        void Update(Comment entity);
        void Delete(Comment entity);
    }
}
