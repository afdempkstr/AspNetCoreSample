using System.Collections.Generic;

namespace AspNetCoreSample.Models
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> AllCandidates { get; }

        Candidate GetCandidateById(int candidateId);

        IEnumerable<Candidate> PopularCandidates();
    }
}
