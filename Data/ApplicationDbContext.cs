using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public required DbSet<User> Users { get; set; }
        public required DbSet<Activity> Activities { get; set; }
        public required DbSet<Registration> Registrations { get; set; }
        public required DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de la relation User <-> Registration <-> Activity
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.UserId, r.ActivityId });

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.User)
                .WithMany(u => u.Registrations)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Activity)
                .WithMany(a => a.Registrations)
                .HasForeignKey(r => r.ActivityId);

            // Configuration de la relation User <-> Group
            modelBuilder.Entity<User>()
                .HasOne(u => u.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
