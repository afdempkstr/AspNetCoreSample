using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSample.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Specialisation> Specialisations { get; set; }

        public DbSet<SelectedTeamCandidate> SelectedTeamCandidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Specialisation>().HasData(new Specialisation { Id = 1, Name = "C# Developer", Description = "A C# back end Developer..." });
            modelBuilder.Entity<Specialisation>().HasData(new Specialisation { Id = 2, Name = "Java Developer", Description = "A Java back end Developer..." });
            modelBuilder.Entity<Specialisation>().HasData(new Specialisation { Id = 3, Name = "Full-Stack Developer", Description = "A developer who can write everything" });

            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 1,
                LastName = "Papadopoulos",
                FirstName = "Nick",
                Rating = 15.95M,
                Description = "Lorem Ipsum",
                SpecialisationId = 1,
                IsPopularCandidate = true,
                IsAvailable = true,
                ImageThumbnailUrl = "https://randomuser.me/api/portraits/lego/5.jpg",
            });

            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 2,
                LastName = "Katinas",
                FirstName = "John",
                Rating = 16.34M,
                Description = "Lorem Ipsum",
                SpecialisationId = 2,
                IsPopularCandidate = false,
                IsAvailable = true,
                ImageThumbnailUrl = "https://randomuser.me/api/portraits/lego/3.jpg",
            });

            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 3,
                LastName = "Floyd",
                FirstName = "George",
                Rating = 17.12M,
                Description = "Lorem Ipsum",
                SpecialisationId = 3,
                IsPopularCandidate = false,
                IsAvailable = true,
                ImageThumbnailUrl = "https://randomuser.me/api/portraits/lego/8.jpg"
            });

            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 4,
                LastName = "Taylor",
                FirstName = "Breonna",
                Rating = 18.44M,
                Description = "Black Lives Matter",
                SpecialisationId = 3,
                IsPopularCandidate = true,
                IsAvailable = true,
                ImageThumbnailUrl = "https://randomuser.me/api/portraits/lego/2.jpg",
            });
        }
    }
}
