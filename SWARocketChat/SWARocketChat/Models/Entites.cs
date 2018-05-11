using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string UserImage { get; set; }

    }

    public class RocketChatContext : DbContext
    {

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(@"server=localhost;port=3306;Database=ProjectRocketChat2;user=root;password=admin");
            }
        }
    }
    //Add-Migration *MigrationName*
    //Update-Database to apply the new migration to the database
}
