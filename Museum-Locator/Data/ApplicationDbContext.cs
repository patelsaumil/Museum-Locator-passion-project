using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Museum_Locator.Models;

namespace Museum_Locator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Core DbSets
        public DbSet<Museum> Museums { get; set; }

        // Use `new` only if your custom User class conflicts with IdentityUser
        public new DbSet<User> Users { get; set; }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Museum_Facility> Museum_Facilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Keep this!

            // Configure many-to-many composite key
            modelBuilder.Entity<Museum_Facility>()
                .HasKey(mf => new { mf.Museum_Id, mf.Facility_Id });

            modelBuilder.Entity<Museum_Facility>()
                .HasOne(mf => mf.Museum)
                .WithMany(m => m.MuseumFacilities)
                .HasForeignKey(mf => mf.Museum_Id);

            modelBuilder.Entity<Museum_Facility>()
                .HasOne(mf => mf.Facility)
                .WithMany(f => f.MuseumFacilities)
                .HasForeignKey(mf => mf.Facility_Id);
        }
    }
}
