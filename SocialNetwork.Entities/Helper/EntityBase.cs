using SocialNetwork.Entities.Helper;
using System;
using System.ComponentModel;

namespace SocialNetwork.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        [DisplayName(DisplayName.CreateDate)]
        public DateTime CreateDate { get; set; }

        [DisplayName(DisplayName.UpdateDate)]
        public DateTime UpdateDate { get; set; }

        [DisplayName(DisplayName.Enabled)]
        public bool Enabled { get; set; }
    }
}
