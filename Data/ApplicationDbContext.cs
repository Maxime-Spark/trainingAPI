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
        public required DbSet<ActivityAccess> ActivityAccesses { get; set; }

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

            // Configuration de la relation Activity <-> ActivityAccess
            

            // Configuration de la relation User <-> Group
            modelBuilder.Entity<User>()
                .HasOne(u => u.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            

            // Seeding de la table Groups
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "admin" }, 
                new Group { Id = 2, Name = "student" }
            );

            // Seeding de la table Users
            // Hash les mots de passe avant de les inclure dans le seed
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("12345");

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Max", Email = "maxforain@gmail.com", Password = hashedPassword, Role = "admin", GroupId = 1 },
                new User { Id = 2, Name = "User1", Email = "user1@example.com", Password = hashedPassword, Role = "student", GroupId = 2 }
            );
        }
    }
}
