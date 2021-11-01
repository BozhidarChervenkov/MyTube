namespace MyTube.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using MyTube.Models;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<PlaylistRecord> PlayListRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Video>()
                .HasOne(v => v.ApplicationUser)
                .WithMany(au => au.Videos);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.ApplicationUser);

            builder.Entity<Comment>()
                .HasMany(c => c.Replies)
                .WithOne(r => r.Comment);

            builder.Entity<Vote>()
                .HasOne(v => v.Video);

            builder.Entity<Vote>()
                .HasOne(v => v.ApplicationUser);
        }
    }
}
