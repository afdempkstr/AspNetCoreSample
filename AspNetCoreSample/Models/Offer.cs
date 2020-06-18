using System;
using System.Collections.Generic;

namespace AspNetCoreSample.Models
{
    public class Offer
    {
        public int ID { get; set; }

        public List<OfferDetail> OfferDetails { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public decimal OfferTotal { get; set; }

        public DateTime OfferPlacedDate { get; set; }
    }
}
