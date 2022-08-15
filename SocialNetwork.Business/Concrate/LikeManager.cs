using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Concrate
{
    public class LikeManager : ILikeService
    {
        private ILikeDal _likeDal;
        public LikeManager(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }
        public void Create(Like entity)
        {
            _likeDal.Create(entity);
        }

        public void Delete(Like entity)
        {
            _likeDal.Delete(entity);
        }

        public List<Like> GetAll()
        {
            return _likeDal.GetAll();
        }

        public Like GetById(Guid id)
        {
            return _likeDal.GetById(id);
        }

        public void Update(Like entity)
        {
            _likeDal.Update(entity);
        }
    }
}
