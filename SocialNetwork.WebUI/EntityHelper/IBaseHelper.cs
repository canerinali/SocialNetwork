using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.EntityHelper
{
    public interface IBaseHelper 
    {
        public EntityBase CreateDefaultProperty(EntityBase entity);
        public EntityBase UpdateDefaultProperty(EntityBase entity);
    }
}
