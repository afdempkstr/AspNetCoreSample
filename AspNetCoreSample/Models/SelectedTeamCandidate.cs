using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.Models
{
    public class SelectedTeamCandidate
    {
        public int SelectedTeamCandidateId { get; set; }

        public Candidate Candidate { get; set; }

        public string SelectedTeamId { get; set; }

        public int OfferPrice { get; set; }
    }
}
