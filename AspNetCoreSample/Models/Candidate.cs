namespace AspNetCoreSample.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Description { get; set; }

        public decimal Rating { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public bool IsPopularCandidate { get; set; }

        public bool IsAvailable { get; set; }

        public int SpecialisationId { get; set; }

        public Specialisation Specialisation { get; set; }

        public string SpecialCase { get; set; }
    }
}
