namespace AspNetCoreSample.Models
{
    public class OfferDetail
    {
        public int Id { get; set; }

        public int OfferId { get; set; }

        public int CandidateId { get; set; }

        public int OfferPrice { get; set; }

        public Candidate Candidate { get; set; }

        public Offer Request { get; set; }
    }
}
