using HrApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HrApi
{
    public class HrContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }

        public HrContext(DbContextOptions<HrContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Candidate>(e =>
            {
                e.Property(e => e.Id).HasConversion(
                    guid => guid.ToString("D"),
                    str => Guid.Parse(str)
                );

            });

            builder.Entity<Candidate>()
                .HasMany(c => c.Interactions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
