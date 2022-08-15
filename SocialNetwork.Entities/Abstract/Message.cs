namespace SocialNetwork.Entities
{
    public class Message : EntityBase
    {
        public string Text { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }

        public virtual SocialMediaAccount SocialMediaAccount { get; set; }
    }
}
