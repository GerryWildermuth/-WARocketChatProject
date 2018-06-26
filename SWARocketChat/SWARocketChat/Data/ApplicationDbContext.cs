using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Models;

namespace SWARocketChat.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<ChatroomMembers> ChatroomMembers { get; set; }
        public DbSet<Message>  Messages{ get; set; }
        public DbSet<UserRoomList>  UserRoomLists{ get; set; }
        //https://blog.oneunicorn.com/2017/09/25/many-to-many-relationships-in-ef-core-2-0-part-1-the-basics/
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Chatroom>()
                .HasIndex(x => x.ChatroomName).IsUnique();
            builder.Entity<UserRoomList>()
                .HasIndex(x => new { x.ChatroomId, x.ApplicationUserId }).IsUnique();
            builder.Entity<UserChatroomMember>()
                .HasKey(k => new { k.ChatroomMembersId, k.ApplicationUserId });

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

            //builder.Entity<ApplicationUser>()
            //    .HasMany(u => u.UserChatroomMembers).WithOne(u => u.User).OnDelete(DeleteBehavior.SetNull);
            //builder.Entity<Message>().HasOne(u => u.User).WithOne().OnDelete(DeleteBehavior.SetNull);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
