using System;
using System.Collections.Generic;

namespace SocialNetwork.Entities
{
    public class SocialMediaMail : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid? SendMailId { get; set; }
        public virtual ICollection<SendMail> SendMails { get; set; }

        public Guid? IncommingMailId { get; set; }
        public virtual ICollection<IncommingMail> IncommingMails { get; set; }
    }
}
