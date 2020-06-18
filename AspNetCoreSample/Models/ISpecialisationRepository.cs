using System.Collections.Generic;

namespace AspNetCoreSample.Models
{
    public interface ISpecialisationRepository
    {
        IEnumerable<Specialisation> AllSpecialisations { get; }

        Specialisation GetSpecialisationById(int specializationId);
    }
}
