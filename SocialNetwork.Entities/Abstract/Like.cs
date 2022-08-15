namespace SocialNetwork.Entities
{
    public class Like : EntityBase
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string isLike { get; set; }

        public virtual Post Post { get; set; }
    }
}
