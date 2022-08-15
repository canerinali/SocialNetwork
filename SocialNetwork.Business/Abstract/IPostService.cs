using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface IPostService
    {
        Post GetById(Guid id);
        List<Post> GetAll();
        void Create(Post entity);
        void Update(Post entity);
        void Delete(Post entity);
    }
}
