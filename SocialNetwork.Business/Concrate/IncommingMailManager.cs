using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Concrate
{
    public class IncommingMailManager : IIncommingMailService
    {
        private IIncommingMailDal  _incommingMailDal;
        public IncommingMailManager(IIncommingMailDal incommingMailDal)
        {
            _incommingMailDal = incommingMailDal;
        }

        public void Create(IncommingMail entity)
        {
            _incommingMailDal.Create(entity);
        }

        public void Delete(IncommingMail entity)
        {
            _incommingMailDal.Delete(entity);
        }

        public List<IncommingMail> GetAll()
        {
            return _incommingMailDal.GetAll();
        }

        public IncommingMail GetById(Guid id)
        {
            return _incommingMailDal.GetById(id);
        }

        public void Update(IncommingMail entity)
        {
            _incommingMailDal.Update(entity);
        }
    }
}
