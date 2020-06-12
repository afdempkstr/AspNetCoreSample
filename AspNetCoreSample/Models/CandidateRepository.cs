using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.Models
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _appDbContext;

        public CandidateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Candidate> AllCandidates => _appDbContext.Candidates.Include(c => c.Specialisation);

        public Candidate GetCandidateById(int candidateId)
        {
            return _appDbContext.Candidates.Include(c => c.Specialisation).FirstOrDefault(c => c.Id == candidateId);
        }

        public IEnumerable<Candidate> PopularCandidates() => _appDbContext.Candidates.Include(c => c.Specialisation)
            .Where(c => c.IsPopularCandidate);
    }
}
