using SocialNetwork.Business.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Concrate
{
    public class PreferenceManager : IPreferenceService
    {
        private IPreferenceDal _preferenceDal;
        public PreferenceManager(IPreferenceDal preferenceDal)
        {
            _preferenceDal = preferenceDal;
        }

        public void Create(Preference entity)
        {
            _preferenceDal.Create(entity);
        }

        public void Delete(Preference entity)
        {
            _preferenceDal.Delete(entity);
        }

        public List<Preference> GetAll()
        {
            return _preferenceDal.GetAll();
        }

        public Preference GetById(Guid id)
        {
            return _preferenceDal.GetById(id);
        }

        public void Update(Preference entity)
        {
            _preferenceDal.Update(entity);
        }
    }
}
