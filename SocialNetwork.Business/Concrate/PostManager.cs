using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Concrate
{
    public class PostManager : IPostService
    {
        private IPostDal _postDal;
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }
        public void Create(Post entity)
        {
            _postDal.Create(entity);
        }

        public void Delete(Post entity)
        {
            _postDal.Delete(entity);
        }

        public List<Post> GetAll()
        {
            return _postDal.GetAll();
        }

        public Post GetById(Guid id)
        {
            return _postDal.GetById(id);
        }

        public void Update(Post entity)
        {
            _postDal.Update(entity);
        }
    }
}
