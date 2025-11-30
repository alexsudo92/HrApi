using HrApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HrApi
{
    public class HrContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Interaction> Interactions { get; set; }

        public HrContext(DbContextOptions<HrContext> options) : base(options) { }
    }
}
