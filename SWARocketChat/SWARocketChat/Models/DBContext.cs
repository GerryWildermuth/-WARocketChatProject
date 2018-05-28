using Microsoft.EntityFrameworkCore;

namespace SWARocketChat.Models
{
    public class RocketChatContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(@"server=localhost;port=3306;Database=ProjectRocketChat;user=root;password=root");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Username).IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Chatroom>()
                .HasIndex(x => x.ChatroomName).IsUnique();
            modelBuilder.Entity<FriendList>()
                .HasIndex(x => x.Username).IsUnique();

        }
    }

    //Add-Migration *MigrationName*
    //Update-Database to apply the new migration to the database
}
