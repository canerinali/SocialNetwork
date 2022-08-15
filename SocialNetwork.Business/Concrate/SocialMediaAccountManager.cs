using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Concrate
{
    public class SocialMediaAccountManager : ISocialMediaAccountService
    {
        private ISocialMediaAccountDal _socialMediaAccountDal;
        public SocialMediaAccountManager(ISocialMediaAccountDal socialMediaAccountDal)
        {
            _socialMediaAccountDal = socialMediaAccountDal;
        }
        public void Create(SocialMediaAccount entity)
        {
            _socialMediaAccountDal.Create(entity);
        }

        public void Delete(SocialMediaAccount entity)
        {
            _socialMediaAccountDal.Delete(entity);
        }

        public List<SocialMediaAccount> GetAll()
        {
            return _socialMediaAccountDal.GetAll();
        }

        public SocialMediaAccount GetById(Guid id)
        {
            return _socialMediaAccountDal.GetById(id);
        }

        public void Update(SocialMediaAccount entity)
        {
            _socialMediaAccountDal.Update(entity);
        }
    }
}
