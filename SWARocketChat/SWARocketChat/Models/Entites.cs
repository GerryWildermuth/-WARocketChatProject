using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string UserImage { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
    public class FriendList
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public string Username { get; set; }
    }
    public class MemberList
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public string Username { get; set; }
    }

    public class Chatroom
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ChatroomName { get; set; }
        public ICollection<User> Users { get; set; }
        public Guid UserId { get; set; }
    }

    public class RocketChatContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(@"server=localhost;port=3306;Database=ProjectRocketChat;user=root;password=admin");
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

        }
    }
     
    //Add-Migration *MigrationName*
    //Update-Database to apply the new migration to the database
}
