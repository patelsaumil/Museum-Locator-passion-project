using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Museum_Locator.Models;

namespace Museum_Locator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Museum> Museums { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<MuseumFacility> MuseumFacilities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MuseumFacility>()
                .HasKey(mf => mf.MuseumFacilityId);

            modelBuilder.Entity<MuseumFacility>()
                .HasOne(mf => mf.Museum)
                .WithMany(m => m.MuseumFacilities)
                .HasForeignKey(mf => mf.MuseumId);

            modelBuilder.Entity<MuseumFacility>()
                .HasOne(mf => mf.Facility)
                .WithMany(f => f.MuseumFacilities)
                .HasForeignKey(mf => mf.FacilityId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Museum)
                .WithMany(m => m.Feedbacks)
                .HasForeignKey(f => f.MuseumId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
