using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreSample.Models
{
    public class MockSpecialisationRepository : ISpecialisationRepository
    {
        private List<Specialisation> _specialisations = new List<Specialisation>
        {
            new Specialisation() { Id = 1, Name = "C# Developer", Description = "C# developer" },
            new Specialisation() { Id = 2, Name = "Java Developer", Description = "poor guy" },
            new Specialisation() { Id = 3, Name = "JS developer", Description= "Node JS full stack engineer" }
        };

        public IEnumerable<Specialisation> AllSpecialisations => _specialisations;

        public Specialisation GetSpecialisationById(int specializationId)
        {
            return _specialisations.FirstOrDefault(s => s.Id == specializationId);
        }
    }
}
