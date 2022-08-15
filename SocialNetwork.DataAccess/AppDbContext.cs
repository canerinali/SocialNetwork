using Microsoft.EntityFrameworkCore;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=94.73.145.9;Database=u5843116_SOC;Uid=u5843116_userSOC;Pwd=JZca58R1EEal08Z;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=u5843116_SOC;integrated security=true;");
        }

        public virtual DbSet<Comment> Comments  { get; set; }
        public virtual DbSet<IncommingMail>  IncommingMails  { get; set; }    
        public virtual DbSet<Like> Likes  { get; set; }
        public virtual DbSet<Message> Messages  { get; set; }
        public virtual DbSet<Post> Posts  { get; set; }
        public virtual DbSet<Preference> Preferences  { get; set; }
        public virtual DbSet<SendMail> SendMails  { get; set; }
        public virtual DbSet<SocialMediaAccount> SocialMediaAcounts  { get; set; }
        public virtual DbSet<SocialMediaMail> SocialMediaMails  { get; set; }
        public virtual DbSet<Ticket> Tickets  { get; set; }
        public virtual DbSet<User> Users  { get; set; }
    }
}
