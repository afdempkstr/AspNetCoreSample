using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.Models
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly SelectedTeam _selectedTeam;

        public OfferRepository(AppDbContext appDbContext, SelectedTeam selectedTeam)
        {
            _appDbContext = appDbContext;
            _selectedTeam = selectedTeam;
        }

        public void CreateOffer(Offer offer)
        {
            if (offer == null)
            {
                return;
            }

            var selectedTeamCandidates = _selectedTeam.SelectedTeamCandidates;
            offer.OfferPlacedDate = DateTime.Now;
            offer.OfferTotal = _selectedTeam.GetSelectedTeamTotalOffer();

            offer.OfferDetails = new List<OfferDetail>();

            foreach (var selectedTeamCandidate in selectedTeamCandidates)
            {
                offer.OfferDetails.Add(new OfferDetail()
                {
                    CandidateId = selectedTeamCandidate.Candidate.Id,
                    OfferPrice = selectedTeamCandidate.OfferPrice
                });
            }

            _appDbContext.Offers.Add(offer);
            _appDbContext.SaveChanges();
        }
    }
}
