namespace SocialNetwork.Entities
{
    public class Ticket : EntityBase
    {
        public string Title { get; set; }

        public virtual Post Post { get; set; }
    }
}
