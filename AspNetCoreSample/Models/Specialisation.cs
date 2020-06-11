using System.Collections.Generic;

namespace AspNetCoreSample.Models
{
    public class Specialisation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Candidate> Candidates { get; set; }
    }
}
