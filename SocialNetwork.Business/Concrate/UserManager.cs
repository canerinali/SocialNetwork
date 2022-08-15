using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Business.Concrate
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Create(User entity)
        {
            _userDal.Create(entity);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(Guid id)
        {
            return _userDal.GetById(id);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }

        public User GetGuidByMailPass(string mail, string password)
        {
            return _userDal.GetAll().Where(x => x.Mail == mail && x.Password == password).FirstOrDefault();
        }
    }
}
