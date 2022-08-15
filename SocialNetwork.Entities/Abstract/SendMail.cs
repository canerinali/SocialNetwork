namespace SocialNetwork.Entities
{
    public class SendMail : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Account { get; set; }

        public virtual SocialMediaMail SocialMediaMail { get; set; }
    }
}
