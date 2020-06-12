using AspNetCoreSample.Models;
using System.Collections.Generic;

namespace AspNetCoreSample.ViewModels
{
    public class HomePageViewModel
    {
        public string Header { get; set; }

        public IEnumerable<Candidate> PopularCandidates { get; set; }
    }
}
