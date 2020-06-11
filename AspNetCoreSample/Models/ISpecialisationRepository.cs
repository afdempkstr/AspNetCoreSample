using System.Collections.Generic;

namespace AspNetCoreSample.Models
{
    interface ISpecialisationRepository
    {
        IEnumerable<Specialisation> AllSpecialisations { get; }

        Specialisation GetSpecialisationById(int specializationId);
    }
}
