using Microsoft.EntityFrameworkCore;

namespace bootcamp.Models
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships
            modelBuilder.Entity<JobListing>()
                .HasOne(j => j.Employer)
                .WithMany(e => e.JobListings)
                .HasForeignKey(j => j.EmployerId);

            modelBuilder.Entity<Applicant>()
                .HasOne(a => a.JobListing)
                .WithMany(j => j.Applicants)
                .HasForeignKey(a => a.JobListingId);
        }

        
    }
}