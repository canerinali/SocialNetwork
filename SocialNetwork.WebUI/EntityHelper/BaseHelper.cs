using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.EntityHelper
{
    public class BaseHelper : IBaseHelper
    {
        public EntityBase CreateDefaultProperty(EntityBase entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.Enabled = true;

            return entity;
        }

        public EntityBase UpdateDefaultProperty(EntityBase entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.Enabled = true;

            return entity;
        }
    }
}
