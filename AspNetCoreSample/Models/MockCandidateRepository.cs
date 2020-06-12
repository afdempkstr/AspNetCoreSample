using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreSample.Models
{
    public class MockCandidateRepository : ICandidateRepository
    {
        private readonly ISpecialisationRepository _specialisationRepository = new MockSpecialisationRepository();

        private List<Candidate> _candidates;

        public MockCandidateRepository()
        {
            var specs = _specialisationRepository.AllSpecialisations.ToList();

            _candidates = new List<Candidate>
            {
                new Candidate() { Id = 1, LastName="Papadopoulos", FirstName="Nick", Rating=15.95M, Description="Lorem Ipsum", SpecialisationId = 1, Specialisation = specs[0], ImageThumbnailUrl="https://randomuser.me/api/portraits/lego/5.jpg" },
                new Candidate() { Id = 2, LastName="Katinas", FirstName="John", Rating=18.95M, Description="Lorem Ipsum", SpecialisationId = 2, Specialisation = specs[1], ImageThumbnailUrl="https://randomuser.me/api/portraits/lego/2.jpg"},
                new Candidate() { Id = 3, LastName="Floyd", FirstName="George", Rating=15.95M, Description="Lorem Ipsum", SpecialisationId = 1, Specialisation = specs[0], ImageThumbnailUrl="https://randomuser.me/api/portraits/lego/3.jpg"},
                new Candidate() { Id = 4, LastName="Lampridis", FirstName="Stergios", Rating=12.95M, Description="Lorem Ipsum", SpecialisationId = 3, Specialisation = specs[2], ImageThumbnailUrl="https://randomuser.me/api/portraits/lego/8.jpg"}
            };
        }

        public IEnumerable<Candidate> AllCandidates => _candidates;

        public Candidate GetCandidateById(int candidateId)
        {
            return _candidates.FirstOrDefault(c => c.Id == candidateId);
        }

        public IEnumerable<Candidate> PopularCandidates()
        {
            return _candidates.Where(c => c.IsPopularCandidate);
        }
    }
}
