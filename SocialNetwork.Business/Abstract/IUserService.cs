using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface IUserService
    {
        User GetById(Guid id);
        List<User> GetAll();
        void Create(User entity);
        void Update(User entity);
        void Delete(User entity);
        User GetGuidByMailPass(string mail, string password);
    }
}
