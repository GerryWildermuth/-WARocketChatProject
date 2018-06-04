using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Models;

namespace SWARocketChat.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<ChatroomMembers> ChatroomMembers { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<Message>  Messages{ get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<IdentityUser>().ToTable("user");
            //builder.Entity<ApplicationUser>().ToTable("user");

            //builder.Entity<IdentityRole>().ToTable("role");
            //builder.Entity<IdentityUserRole>().ToTable("userrole");
            //builder.Entity<IdentityUserClaim>().ToTable("userclaim");
            //builder.Entity<IdentityUserLogin>().ToTable("userlogin");
            //builder.Entity<User>()
            //    .HasIndex(x => x.Username).IsUnique();
            //builder.Entity<User>()
            //.HasIndex(x => x.Email).IsUnique();
            builder.Entity<Chatroom>()
                .HasIndex(x => x.ChatroomName).IsUnique();
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
