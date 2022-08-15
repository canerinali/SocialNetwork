using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Concrate
{
    public class SendMailManager : ISendMailService
    {
        private ISendMailDal _sendMailDal;
        public SendMailManager(ISendMailDal sendMailDal)
        {
            _sendMailDal = sendMailDal;
        }
        public void Create(SendMail entity)
        {
            _sendMailDal.Create(entity);
        }

        public void Delete(SendMail entity)
        {
            _sendMailDal.Delete(entity);
        }

        public List<SendMail> GetAll()
        {
            return _sendMailDal.GetAll();
        }

        public SendMail GetById(Guid id)
        {
            return _sendMailDal.GetById(id);
        }

        public void Update(SendMail entity)
        {
            _sendMailDal.Update(entity);
        }
    }
}
