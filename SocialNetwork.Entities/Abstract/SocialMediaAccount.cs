using System;
using System.Collections.Generic;

namespace SocialNetwork.Entities
{
    public class SocialMediaAccount : EntityBase
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialId { get; set; }


        public virtual User User { get; set; }
        public Guid? UserId { get; set; }

        public Guid? MessageId { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        public Guid? PostId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
