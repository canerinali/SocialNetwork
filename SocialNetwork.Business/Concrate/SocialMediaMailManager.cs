using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Concrate
{
    public class SocialMediaMailManager : ISocialMediaMailService
    {
        private ISocialMediaMailDal  _socialMediaMailDal;
        public SocialMediaMailManager(ISocialMediaMailDal  socialMediaMailDal)
        {
            _socialMediaMailDal = socialMediaMailDal;
        }

        public void Create(SocialMediaMail entity)
        {
            _socialMediaMailDal.Create(entity);
        }

        public void Delete(SocialMediaMail entity)
        {
            _socialMediaMailDal.Delete(entity);
        }

        public List<SocialMediaMail> GetAll()
        {
           return _socialMediaMailDal.GetAll();
        }

        public SocialMediaMail GetById(Guid id)
        {
            return _socialMediaMailDal.GetById(id);
        }

        public void Update(SocialMediaMail entity)
        {
            _socialMediaMailDal.Update(entity);
        }
    }
}
