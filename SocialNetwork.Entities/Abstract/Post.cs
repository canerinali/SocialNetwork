using System;
using System.Collections.Generic;

namespace SocialNetwork.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime TaskDate { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public string Visibility { get; set; }
        public string State { get; set; }
        public string CalendarJs { get; set; }

        public Guid? SocailMediaId { get; set; }
        public virtual SocialMediaAccount SocialMediaAccount { get; set; }

        public Guid? CommentId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Guid? LikeId { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public Guid? TicketId { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
