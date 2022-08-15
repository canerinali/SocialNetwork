namespace SocialNetwork.Entities
{
    public class Comment : EntityBase
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Text { get; set; }

        public virtual Post Post { get; set; }
    }
}
