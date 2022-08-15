using System;
using System.Collections.Generic;

namespace SocialNetwork.Entities
{
    public class User : EntityBase
    {
        public static object Claims { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public virtual Preference Preference { get; set; }
        public virtual SocialMediaMail SocialMediaMail { get; set; }

        public Guid? SocialMediaAcountId { get; set; }
        public virtual ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
    }
}
