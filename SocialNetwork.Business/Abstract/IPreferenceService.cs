using SocialNetwork.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Business.Abstract
{
    public interface IPreferenceService
    {
        Preference GetById(Guid id);
        List<Preference> GetAll();
        void Create(Preference entity);
        void Update(Preference entity);
        void Delete(Preference entity);
    }
}
