using System;

namespace SocialNetwork.Entities
{
    public class Preference : EntityBase
    {
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public string TimeFormat { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
