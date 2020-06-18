using AspNetCoreSample.Models;
using System.Collections.Generic;

namespace AspNetCoreSample.ViewModels
{
    public class CandidateListViewModel
    {
        public IEnumerable<Candidate> Candidates { get; set; }

        public string CurrentSpecialisation { get; set; }
    }
}
