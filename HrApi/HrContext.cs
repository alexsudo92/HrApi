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

        public HrContext(DbContextOptions<HrContext> options) : base(options) { }
    }
}
