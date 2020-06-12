using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSample.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Specialisation> Specialisations { get; set; }

    }
}
